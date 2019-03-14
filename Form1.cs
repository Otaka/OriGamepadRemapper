using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX.DirectInput;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace OriGamepadRemapper
{
    public partial class Form1 : Form
    {
        private JoystickHelper joystickHelper;
        string[] buttonNames;
        TextBox[] buttonTextBoxes;
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            JoystickHelper helper = new JoystickHelper();
            List<JoystickDescriptor>joysticks=helper.DetectDevices();
            foreach (JoystickDescriptor jd in joysticks) {
                gamepadsComboBox.Items.Add(jd);
            }
            if (joysticks.Count > 0) {
                gamepadsComboBox.SelectedIndex = 0;
            }
            else {
                MessageBox.Show("Cannot find any gamepads");
                loadConfigButton.Enabled = false;
                saveConfigButton.Enabled = false;
            }

            helper.StopCapture();

            buttonNames =new string[] { "A", "B", "X", "Y", "LShoulder", "RShoulder", "Select", "Start", "LTrigger", "RTrigger" };
            buttonTextBoxes =new TextBox[]{ ATextbox,BTextbox,XTextbox,YTextbox,LSTextbox,RSTextbox,SelectTextbox,StartTextbox,LTTextbox,RTTextbox };
            tryToAutomaticallyLoadConfigFile();

            string appDataFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string oriProfileFolder = appDataFolderPath + "\\" + "Ori and the Blind Forest DE";
            saveFileDialog1.InitialDirectory = oriProfileFolder;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e){
            if (joystickHelper != null) {
                joystickHelper.StopCapture();
            }
            Environment.Exit(0);
        }

        void onJoystickButton(object sender, EventArgs e) {
            JoystickButtonPressedEventArgs eventArg = (JoystickButtonPressedEventArgs)e;
            int button = (int)eventArg.offset - (int)JoystickOffset.Buttons0 + 1;
            var focused = FindFocusedControl(this);
            if (focused is TextBox) {
                pictureBox1.Invoke((MethodInvoker)delegate {
                    ((TextBox)focused).Text = "" + button;
                });
            }
        }

        private void gamepadsComboBox_SelectedIndexChanged(object sender, EventArgs e){
            JoystickDescriptor joystick= (JoystickDescriptor)gamepadsComboBox.SelectedItem;
            if (joystickHelper != null) {
                joystickHelper.StopCapture();
                joystickHelper = null;
            }
            joystickHelper = new JoystickHelper();
            joystickHelper.JoystickButtonPressed += onJoystickButton;
            joystickHelper.StartCapture(joystick.instanceGuid);
        }

        private void tryToAutomaticallyLoadConfigFile() {
            string appDataFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string oriGamepadConfigPath = appDataFolderPath + "\\" + "Ori and the Blind Forest DE\\ControllerButtonRemaps.txt";
            try{
                if (File.Exists(oriGamepadConfigPath)){
                    loadConfig(oriGamepadConfigPath);
                }
            } catch (Exception ex) {
                MessageBox.Show("Error while loading controller config [" + oriGamepadConfigPath + "]\n"+ex.Message);
            }
        }

        private void loadConfigButton_Click(object sender, EventArgs e) {
            DialogResult result= openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) {
                string path = openFileDialog1.FileName;
                loadConfig(path);
            }
        }       

        private void loadConfig(string filePath) {
            string content=File.ReadAllText(filePath);
            string lineToSearch = @"Activate DirectInput Button Rebinding";
            Regex magiclineTester = new Regex(lineToSearch);
            if (!magiclineTester.Match(content).Success) {
                MessageBox.Show("Cannot find necessary line in config file ["+lineToSearch+"]");
                return;
            }

            string[] searchRegexps = new string[] {@"A\s*:\s*(\d+)", @"B\s*:\s*(\d+)", @"X\s*:\s*(\d+)", @"Y\s*:\s*(\d+)", @"LShoulder\s*:\s*(\d+)", @"RShoulder\s*:\s*(\d+)", @"Select\s*:\s*(\d+)", @"Start\s*:\s*(\d+)", @"LTrigger\s*:\s*(\d+)", @"RTrigger\s*:\s*(\d+)" };
            for (int i = 0; i < searchRegexps.Length; i++) {
                Regex valueExtractor = new Regex(searchRegexps[i]);
                Match match = valueExtractor.Match(content);
                if (!match.Success) {
                    MessageBox.Show("Cannot find button value with regexp ["+searchRegexps[i]+"]");
                    return;
                }
                int buttonValue = Int32.Parse(match.Groups[1].Value);
                TextBox textBox = buttonTextBoxes[i];
                textBox.Text = "" + buttonValue;
            }
        }

        private void saveConfigButton_Click(object sender, EventArgs e) {
            TextBox emptyField = getEmptyField();
            if (emptyField != null) {
                MessageBox.Show("Please fill action");
                emptyField.Focus();
                return;
            }

            DialogResult result= saveFileDialog1.ShowDialog();
            if (result == DialogResult.OK) {
                saveConfig(saveFileDialog1.FileName);
            }
        }

        private TextBox getEmptyField() {
            for (int i = 0; i < buttonTextBoxes.Length; i++) {
                if (buttonTextBoxes[i].Text.Trim().Length == 0) {
                    return buttonTextBoxes[i];
                }
            }
            return null;
        }

        private string getNotUsedButton(HashSet<string>usedButtons) {
            for (int i = 1; i <= 12; i++) {
                string button = "" + i;
                if (!usedButtons.Contains(button)) {
                    usedButtons.Add(button);
                    return button;
                }
            }
            throw new Exception("Cannot allocate new button");
        }

        private void saveConfig(string filePath) {
            ConfigFileTemplate c;
            string content = ConfigFileTemplate.CONFIG_TEMPLATE;
            var usedButtons = new HashSet<string>();
            for (int i = 0; i < buttonNames.Length; i++) {
                string button = buttonNames[i];
                string resultButton = buttonTextBoxes[i].Text;
                usedButtons.Add(resultButton);
                content=content.Replace("${" + button + "}", resultButton);
            }

            content = content.Replace("${LStick}",getNotUsedButton(usedButtons));
            content = content.Replace("${RStick}", getNotUsedButton(usedButtons));

            File.WriteAllText(filePath, content);
        }

        public static Control FindFocusedControl(Control control) {
            var container = control as ContainerControl;
            return (null != container
                ? FindFocusedControl(container.ActiveControl)
                : control);
        }
    }
}
