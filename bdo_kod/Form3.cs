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
            // giriş kabul edilirse listelere erişilebilir.
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
                return;
            }
            // dosya yolları girilir
            string inputFilePath = @"C:\Users\fetik\OneDrive\Masaüstü\2_bahar\biçimsel\bdo_kod\güncelStok.txt";
            string acilStokFilePath = @"C:\Users\fetik\OneDrive\Masaüstü\2_bahar\biçimsel\acilStok.txt";
            string tedarikFilePath = @"C:\Users\fetik\OneDrive\Masaüstü\2_bahar\biçimsel\tedarik.txt";
            // dosya yollarını tedarik.cs sınıfındaki IlacTedarik fonksiyonuyla listeler oluşturulur
            IlacTedarik ilacTedarik = new IlacTedarik(inputFilePath, acilStokFilePath, tedarikFilePath);
            ilacTedarik.IlaclariKontrolEt();

            // Acil stok dosyasını oku ve listBox1'e(Tedarik edilecek ilaçlar) ekle. 
            if (File.Exists(acilStokFilePath))
            {
                var acilStokLines = File.ReadAllLines(acilStokFilePath);
                listBox1.Items.Clear();
                listBox1.Items.AddRange(acilStokLines);
            }
            else
            {
                File.Create(acilStokFilePath).Dispose();
                MessageBox.Show("Acil stok dosyası oluşturuldu.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // Tedarik dosyasını oku ve listBox2'ye(Tedarik bekleyen ilaçlar) ekle
            if (File.Exists(tedarikFilePath))
            {
                var tedarikLines = File.ReadAllLines(tedarikFilePath);
                listBox2.Items.Clear();
                listBox2.Items.AddRange(tedarikLines);
            }
            else
            {
                File.Create(tedarikFilePath).Dispose();
                MessageBox.Show("Tedarik dosyası oluşturuldu.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            // listBox2'deki bütün itemları listBox1'e aktar
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
            }
            else
            {
                File.Create(tedarikFilePath).Dispose();
            }

            List<string> acilStokListesi = new List<string>();
            if (File.Exists(acilStokFilePath))
            {
                acilStokListesi = File.ReadAllLines(acilStokFilePath).ToList();
            }
            else
            {
                File.Create(acilStokFilePath).Dispose();
            }

            acilStokListesi.AddRange(tedarikListesi);
            File.WriteAllLines(acilStokFilePath, acilStokListesi);
            File.Delete(tedarikFilePath);

            MessageBox.Show("İlaçlar başarıyla aktarıldı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        
    }
    }
}
