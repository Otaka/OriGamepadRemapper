using SharpDX.DirectInput;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OriGamepadRemapper {
   public class JoystickDescriptor {
        public Guid instanceGuid;
        public string instanceName;
        public JoystickDescriptor(Guid instanceGuid, string instanceName) {
            this.instanceGuid = instanceGuid;
            this.instanceName = instanceName;
        }

        public override string ToString() {
            return instanceName;
        }
    }

    public class JoystickHelper {
        private DirectInput directInput;
        private Thread pollingThread;
        private Joystick joystick;
        private int startButtonOffset = -1;
        private int lapButtonOffset = -1;


        public JoystickHelper() {
            directInput = new DirectInput();
        }

        public List<JoystickDescriptor> DetectDevices() {
            List<JoystickDescriptor> joystickDescriptors = new List<JoystickDescriptor>();

            // check for gamepads
            foreach (var deviceInstance in directInput.GetDevices(DeviceType.Gamepad, DeviceEnumerationFlags.AllDevices)) {
                joystickDescriptors.Add(new JoystickDescriptor(deviceInstance.InstanceGuid, deviceInstance.InstanceName));
            }

            // check for joysticks
            foreach (var deviceInstance in directInput.GetDevices(DeviceType.Joystick, DeviceEnumerationFlags.AllDevices)) {
                joystickDescriptors.Add(new JoystickDescriptor(deviceInstance.InstanceGuid, deviceInstance.InstanceName));
            }

            return joystickDescriptors;
        }


        public void StartCapture(Guid joystickGuid, int startButtonOffset, int lapButtonOffset) {
            this.startButtonOffset = startButtonOffset;
            this.lapButtonOffset = lapButtonOffset;
            StartCapture(joystickGuid);
        }

        public void StartCapture(Guid joystickGuid) {

            joystick = new Joystick(directInput, joystickGuid);

            joystick.Properties.BufferSize = 128;

            joystick.Acquire();

            pollingThread = new Thread(new ThreadStart(PollJoystick));
            pollingThread.Start();

            // Spin for a while waiting for the started thread to become alive
            while (!pollingThread.IsAlive) ;
        }

        public void StopCapture() {
            if (pollingThread != null) {
                pollingThread.Abort();

                // wait until thread finishes
                pollingThread.Join();
            }

            if (joystick != null) {
                joystick.Dispose();
            }
            if (directInput != null) {
                directInput.Dispose();
            }
        }

        public void PollJoystick() {
            while (true) {
                joystick.Poll();
                JoystickUpdate[] datas = joystick.GetBufferedData();
                foreach (JoystickUpdate state in datas){
                    if (state.Offset >= JoystickOffset.Buttons0 && state.Offset <= JoystickOffset.Buttons127){
                        if (state.Value == 128){
                            // pressed down
                            JoystickButtonPressedEventArgs args = new JoystickButtonPressedEventArgs();
                            args.ButtonOffset = state.RawOffset;
                            args.TimeStamp = DateTime.Now;
                            args.offset = state.Offset;
                            OnJoystickButtonPressed(args);
                            
                            if (state.RawOffset == startButtonOffset) {
                                OnJoystickStartButtonPressed(args);
                            }
                            else if (state.RawOffset == lapButtonOffset) {
                                OnJoystickLapButtonPressed(args);
                            }
                        }
                    }
                }

                Thread.Sleep(10);
            }
        }

        protected virtual void OnJoystickButtonPressed(JoystickButtonPressedEventArgs e) {
            EventHandler<JoystickButtonPressedEventArgs> handler = JoystickButtonPressed;
            if (handler != null) {
                handler(this, e);
            }
        }

        public event EventHandler<JoystickButtonPressedEventArgs> JoystickButtonPressed;

        protected virtual void OnJoystickLapButtonPressed(JoystickButtonPressedEventArgs e) {
            EventHandler<JoystickButtonPressedEventArgs> handler = JoystickLapButtonPressed;
            if (handler != null) {
                handler(this, e);
            }
        }

        public event EventHandler<JoystickButtonPressedEventArgs> JoystickLapButtonPressed;

        protected virtual void OnJoystickStartButtonPressed(JoystickButtonPressedEventArgs e) {
            EventHandler<JoystickButtonPressedEventArgs> handler = JoystickStartButtonPressed;
            if (handler != null) {
                handler(this, e);
            }
        }

        public event EventHandler<JoystickButtonPressedEventArgs> JoystickStartButtonPressed;
    }

    public class JoystickButtonPressedEventArgs : EventArgs {
        public int ButtonOffset { get; set; }
        public DateTime TimeStamp { get; set; }
        public JoystickOffset offset { get; set; }
    }
}
