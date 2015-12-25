using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace teacher_aid_tool
{
    public partial class checksum : Form
    {
        public checksum()
        {
            InitializeComponent();

            listView1.View = View.List;
        }


        private void checksum_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();

                int i, j, keylen=0, msglen=0;
            char[] input = new char[100];
            char[] key = new char[100];
            char[] temp = new char[100];
            char[] quot = new char[100];
            char[] rem = new char[100];
            char[] key1 = new char[100];
            char[] initial_data = new char[100];

            char[]a = Convert.ToString(this.textBox1.Text).ToCharArray();
            char [] b = Convert.ToString(this.textBox2.Text).ToCharArray();

            initial_data = a;
            for (i=0;i< a.Length;i++ )
            {
                input[i] = a[i];
            }
            for (i = 0; i < b.Length; i++)
            {
                key[i] = b[i];
            }

            foreach (char c in input)
            {
                if (c == '\0')
                    break;
                msglen++;
                   
            }
            foreach (char c in key)
            {
                if (c == '\0')
                    break;
                keylen++;

            }

            int count = 0;
            StringBuilder builder = new StringBuilder();
            StringBuilder builder2 = new StringBuilder();

            for (i=0;i<keylen;i++)
            {
                count = keylen - i-1;
                if (key[i] == '1')
                {
                    builder.Append("x*" + count);
                    if(count!=0)
                    builder.Append("+");

                }


            }
           
            string aa = new string(initial_data);
            string aaa = new string(key);

           // listView1.Items.Add("sender data in bit"+ aa);
            listView1.Items.Add("crc polynomial is\n"+" " + builder);

           // listView1.Items.Add("crc key in bit" + aaa);

            Array.Copy(key,key1,key.Length);
            
            for (i = 0; i < keylen - 1; i++)
            {
                input[msglen + i] = '0';
            }
            
            for (i = 0; i < keylen; i++)
                temp[i] = input[i];
            for (i = 0; i < msglen; i++)
            {
                quot[i] = temp[0];
                if (quot[i] == '0')
                    for (j = 0; j < keylen; j++)
                        key[j] = '0';
                else
                    for (j = 0; j < keylen; j++)
                        key[j] = key1[j];
                for (j = keylen - 1; j > 0; j--)
                {
                    if (temp[j] == key[j])
                        rem[j - 1] = '0';
                    else
                        rem[j - 1] = '1';
                }
                rem[keylen - 1] = input[i + keylen];
                Array.Copy(rem,temp,rem.Length);
            }
            Array.Copy(temp, rem, temp.Length);
            string x_quot = new string(quot);
            string x_rem = new string(rem);
            string x_input = new string(input);
            List<char> final_data = new  List<char>();
            listView1.Items.Add("quotient in bit\n" + x_quot);
            listView1.Items.Add("remainder in bit\n" + x_rem);
            int rem_len=0;
            foreach (char c in x_rem)
            {
                if (c == '\0')
                    break;
                rem_len++;

            }


            count = 0;
            for (i = 0; i <rem_len; i++)
            {
                count = rem_len - i - 1;
                if (x_rem[i] == '1')
                {
                    builder2.Append("x*" + count);
                    if (count != 0)
                        builder2.Append("+");

                }


            }
            listView1.Items.Add("remainder in polynomial is\n " + builder2);

            foreach (char c in initial_data)
            {
                if (c == '\0')
                    break;
                final_data.Add(c);
            }
            foreach (char c in rem)
            {
                if (c == '\0')
                    break;
                final_data.Add(c);
            }
            char[] ss = new char[100];
            i = 0;
            foreach(char c in final_data)
            {
                ss[i++]= c;
            }
            string zz = new string(ss);
            listView1.Items.Add("final data in bit" + zz);

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
