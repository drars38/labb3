using CustomNumberSystem;

namespace labb3  
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // ��������� �������� � ���������� ������
            comboBox1.Items.AddRange(Enum.GetValues(typeof(NumberSystem)).Cast<object>().ToArray());
            comboBox2.Items.AddRange(Enum.GetValues(typeof(NumberSystem)).Cast<object>().ToArray());
            comboBox3.Items.AddRange(Enum.GetValues(typeof(NumberSystem)).Cast<object>().ToArray());
            comboBox4.Items.AddRange(Enum.GetValues(typeof(NumberSystem)).Cast<object>().ToArray());

            // �������� ������ ������� � ������ ������ �� ���������
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string number1Text = textBox1.Text;
            string number2Text = textBox2.Text;
            // �������� ��������� ������� ��������� �� ���������� �������
            NumberSystem system1 = (NumberSystem)comboBox1.SelectedItem;
            NumberSystem system2 = (NumberSystem)comboBox2.SelectedItem;
            // ������� ������� CustomNumber
            CustomNumber num1 = new CustomNumber(number1Text, system1);
            CustomNumber num2 = new CustomNumber(number2Text, system2);
            // ��������� ��������
            CustomNumber sum = num1 + num2;
            label3.Text = $"�����: {sum.GetValue()}";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string number1Text = textBox1.Text;
            string number2Text = textBox2.Text;
            // �������� ��������� ������� ��������� �� ���������� �������
            NumberSystem system1 = (NumberSystem)comboBox1.SelectedItem;
            NumberSystem system2 = (NumberSystem)comboBox2.SelectedItem;
            // ������� ������� CustomNumber
            CustomNumber num1 = new CustomNumber(number1Text, system1);
            CustomNumber num2 = new CustomNumber(number2Text, system2);
            // ��������� ��������
            CustomNumber sum = num1-num2;
            label3.Text = $"�������: {sum.GetValue()}";
        }

        private void button3_Click(object sender, EventArgs e) 
        {
            string number1Text = textBox1.Text;
            string number2Text = textBox2.Text;
            // �������� ��������� ������� ��������� �� ���������� �������
            NumberSystem system1 = (NumberSystem)comboBox1.SelectedItem;
            NumberSystem system2 = (NumberSystem)comboBox2.SelectedItem;
            // ������� ������� CustomNumber
            CustomNumber num1 = new CustomNumber(number1Text, system1);
            CustomNumber num2 = new CustomNumber(number2Text, system2);
            // ��������� ��������
            CustomNumber sum = num1*num2;
            label3.Text = $"������������: {sum.GetValue()}";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string numberText = textBox3.Text;
            NumberSystem sourceSystem = (NumberSystem)comboBox3.SelectedItem;
            NumberSystem targetSystem = (NumberSystem)comboBox4.SelectedItem;

            CustomNumber number = new CustomNumber(numberText, sourceSystem);
            string convertedNumber = number.ConvertTo(targetSystem);

            label4.Text = $"���������: {convertedNumber}";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string number1Text = textBox1.Text;
            string number2Text = textBox2.Text;
            // �������� ��������� ������� ��������� �� ���������� �������
            NumberSystem system1 = (NumberSystem)comboBox1.SelectedItem;
            NumberSystem system2 = (NumberSystem)comboBox2.SelectedItem;
            // ������� ������� CustomNumber
            CustomNumber num1 = new CustomNumber(number1Text, system1);
            CustomNumber num2 = new CustomNumber(number2Text, system2);
            if (num1>num2)
            {
                label3.Text = $"����� {number1Text} > {number2Text}";
            }
            else if(num1==num2)
            {
                label3.Text = $"����� {number1Text} = {number2Text}";
            }
            else
            {
                label3.Text = $"����� {number1Text} < {number2Text}";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        // ���������� ������� KeyPress ��� textField1
        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // ���� ������ ������� Enter
            if (e.KeyChar == (char)Keys.Enter)
            {
                // ��������� ����� �� textField2
                comboBox1.Focus();
            }
        }
        private void ComboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // ���� ������ ������� Enter
            if (e.KeyChar == (char)Keys.Enter)
            {
                // ��������� ����� �� textField2
                textBox2.Focus();
            }
        }
        private void TextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            // ���� ������ ������� Enter
            if (e.KeyChar == (char)Keys.Enter)
            {
                // ��������� ����� �� textField2
                comboBox2.Focus();
            }
        }
        private void ComboBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            // ���� ������ ������� Enter
            if (e.KeyChar == (char)Keys.Enter)
            {
                // ��������� ����� �� textField2
                button1.Focus();
            }
        }
        private void TextBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            // ���� ������ ������� Enter
            if (e.KeyChar == (char)Keys.Enter)
            {
                // ��������� ����� �� textField2
                comboBox3.Focus();
            }
        }
        private void ComboBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            // ���� ������ ������� Enter
            if (e.KeyChar == (char)Keys.Enter)
            {
                // ��������� ����� �� textField2
                comboBox4.Focus();
            }
        }
        private void ComboBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            // ���� ������ ������� Enter
            if (e.KeyChar == (char)Keys.Enter)
            {
                // ��������� ����� �� textField2
                button5.Focus();
            }
        }
    }
}
namespace CustomNumberSystem
{
    public enum NumberSystem
    {
        Binary,
        Octal,
        Decimal,
        Hexadecimal
    }

    public class CustomNumber
    {
        private string _value;
        private NumberSystem _numberSystem;

        public CustomNumber(string value, NumberSystem numberSystem)
        {
            _value = value;
            _numberSystem = numberSystem;
        }

        public static CustomNumber operator +(CustomNumber num1, CustomNumber num2)
        {
            // ������������ ��� ����� � ���������� �������, ��������� �������� � ������������ ��������� �������
            int resultDecimal = num1.ConvertToDecimal() + num2.ConvertToDecimal();
            return new CustomNumber(num1.ConvertFromDecimal(resultDecimal), num1._numberSystem);
        }

        public static CustomNumber operator -(CustomNumber num1, CustomNumber num2)
        {
            // ������������ ��� ����� � ���������� �������, ��������� ��������� � ������������ ��������� �������
            int resultDecimal = num1.ConvertToDecimal() - num2.ConvertToDecimal();
            return new CustomNumber(num1.ConvertFromDecimal(resultDecimal), num1._numberSystem);
        }

        public static CustomNumber operator *(CustomNumber num1, CustomNumber num2)
        {
            // ������������ ��� ����� � ���������� �������, ��������� ��������� � ������������ ��������� �������
            int resultDecimal = num1.ConvertToDecimal() * num2.ConvertToDecimal();
            return new CustomNumber(num1.ConvertFromDecimal(resultDecimal), num1._numberSystem);
        }

        public static bool operator >(CustomNumber num1, CustomNumber num2)
        {
            // ���������� ����� � ���������� �������
            return num1.ConvertToDecimal() > num2.ConvertToDecimal();
        }

        public static bool operator <(CustomNumber num1, CustomNumber num2)
        {
            // ���������� ����� � ���������� �������
            return num1.ConvertToDecimal() < num2.ConvertToDecimal();
        }

        public static bool operator ==(CustomNumber num1, CustomNumber num2)
        {
            // ���������� ����� � ���������� �������
            return num1.ConvertToDecimal() == num2.ConvertToDecimal();
        }

        public static bool operator !=(CustomNumber num1, CustomNumber num2)
        {
            // ���������� ����� � ���������� �������
            return num1.ConvertToDecimal() != num2.ConvertToDecimal();
        }


        public string GetValue()
        {
            return _value;
        }

        private int ConvertToDecimal()
        {
            switch (_numberSystem)
            {
                case NumberSystem.Binary:
                    return Convert.ToInt32(_value, 2);
                case NumberSystem.Octal:
                    return Convert.ToInt32(_value, 8);
                case NumberSystem.Decimal:
                    return Convert.ToInt32(_value);
                case NumberSystem.Hexadecimal:
                    return Convert.ToInt32(_value, 16);
                default:
                    throw new InvalidOperationException("Unknown number system");
            }
        }

        private string ConvertFromDecimal(int decimalValue)
        {
            switch (_numberSystem)
            {
                case NumberSystem.Binary:
                    return Convert.ToString(decimalValue, 2);
                case NumberSystem.Octal:
                    return Convert.ToString(decimalValue, 8);
                case NumberSystem.Decimal:
                    return decimalValue.ToString();
                case NumberSystem.Hexadecimal:
                    return Convert.ToString(decimalValue, 16);
                default:
                    throw new InvalidOperationException("Unknown number system");
            }
        }
        public string ConvertTo(NumberSystem targetSystem)
        {
            // Convert number to decimal first
            int decimalValue = ConvertToDecimal();

            // Convert decimal value to target number system
            switch (targetSystem)
            {
                case NumberSystem.Binary:
                    return Convert.ToString(decimalValue, 2);
                case NumberSystem.Octal:
                    return Convert.ToString(decimalValue, 8);
                case NumberSystem.Decimal:
                    return decimalValue.ToString();
                case NumberSystem.Hexadecimal:
                    return Convert.ToString(decimalValue, 16);
                default:
                    throw new InvalidOperationException("Unknown number system");
            }
        }

    }
}