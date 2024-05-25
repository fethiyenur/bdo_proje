using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bdo_kod
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            if (txtKullanici.Text == "admin" && txtSifre.Text == "admin")
            {
                listBox1.Visible = true;
                listBox2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                button1.Visible = true;
            }
            else
            {
                MessageBox.Show("Kullanıcı adı ya da şifre hatalı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            string inputFilePath = @"C:\Users\fetik\OneDrive\Masaüstü\2_bahar\biçimsel\bdo_kod\güncelStok.txt";
            string acilStokFilePath = @"C:\Users\fetik\OneDrive\Masaüstü\2_bahar\biçimsel\acilStok.txt";
            string tedarikFilePath = @"C:\Users\fetik\OneDrive\Masaüstü\2_bahar\biçimsel\tedarik.txt";
            IlacTedarik ilacTedarik = new IlacTedarik(inputFilePath, acilStokFilePath, tedarikFilePath);
            ilacTedarik.IlaclariKontrolEt();

            // Acil stok dosyasını oku ve listBox1'e ekle
            if (File.Exists(acilStokFilePath))
            {
                var acilStokLines = File.ReadAllLines(acilStokFilePath);
                listBox1.Items.Clear();
                listBox1.Items.AddRange(acilStokLines);
            }
            else
            {
                MessageBox.Show("Acil stok dosyası bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Tedarik dosyasını oku ve listBox2'ye ekle
            if (File.Exists(tedarikFilePath))
            {
                var tedarikLines = File.ReadAllLines(tedarikFilePath);
                listBox2.Items.Clear();
                listBox2.Items.AddRange(tedarikLines);
            }
            else
            {
                MessageBox.Show("Tedarik dosyası bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string tedarikFilePath = @"C:\Users\fetik\OneDrive\Masaüstü\2_bahar\biçimsel\tedarik.txt";
            string acilStokFilePath = @"C:\Users\fetik\OneDrive\Masaüstü\2_bahar\biçimsel\acilStok.txt";
            foreach (var ilac in listBox2.Items)
            {
                listBox1.Items.Add(ilac);
            }
            listBox2.Items.Clear();

            // Tedarik dosyasındaki bütün ilaçları acilStok dosyasına taşı
            List<string> tedarikListesi = new List<string>();
            if (File.Exists(tedarikFilePath))
            {
                tedarikListesi = File.ReadAllLines(tedarikFilePath).ToList();
                if (File.Exists(acilStokFilePath))
                {
                    List<string> acilStokListesi = new List<string>(File.ReadAllLines(acilStokFilePath));
                    acilStokListesi.AddRange(tedarikListesi);
                    File.WriteAllLines(acilStokFilePath, acilStokListesi);
                }
                else
                {
                    File.WriteAllLines(acilStokFilePath, tedarikListesi);
                }
                File.Delete(tedarikFilePath);
                MessageBox.Show("İlaçlar başarıyla aktarıldı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Tedarik dosyası bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
