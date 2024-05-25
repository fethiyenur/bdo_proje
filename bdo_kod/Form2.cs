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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Giris_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string guncelStokFilePath = @"C:\Users\fetik\OneDrive\Masaüstü\2_bahar\biçimsel\bdo_kod\güncelStok.txt";
            string ilacAdi = textBox1.Text.Trim();
            int kullanilanAdet;

            if (!int.TryParse(textBox2.Text.Trim(), out kullanilanAdet))
            {
                MessageBox.Show("Lütfen geçerli bir adet sayısı girin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<string> yeniStokListesi = new List<string>();
            // Güncel stok dosyasını oku
            foreach (var line in File.ReadLines(guncelStokFilePath))
            {
                var parts = line.Split(',');
                if (parts.Length == 2)
                {
                    string ilacAdiDosya = parts[0].Trim();
                    if (ilacAdiDosya == ilacAdi)
                    {
                        int mevcutStok;
                        if (int.TryParse(parts[1].Trim(), out mevcutStok))
                        {
                            int yeniStok = Math.Max(0, mevcutStok - kullanilanAdet);
                            yeniStokListesi.Add($"{ilacAdiDosya}, {yeniStok}");
                        }
                        else
                        {
                            MessageBox.Show("Güncel stok dosyası bozuk, lütfen kontrol edin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    else
                    {
                        yeniStokListesi.Add(line);
                    }
                }
                else
                {
                    MessageBox.Show("Güncel stok dosyası bozuk, lütfen kontrol edin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            
            // Yeni güncel stok listesini dosyaya yaz
            File.WriteAllLines(guncelStokFilePath, yeniStokListesi);

            MessageBox.Show($"{ilacAdi} ilacının stok bilgisi güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
