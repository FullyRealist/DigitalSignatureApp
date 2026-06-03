using System;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;

namespace DigitalSignatureApp
{
    public partial class MainForm : Form
    {
        private string filePath;
        private string userName;
        private string userSurname;

        public MainForm()
        {
            InitializeComponent();
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Word Documents|*.doc;*.docx";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog.FileName;
                filePathLabel.Text = filePath;
            }
        }

        private void signButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(filePath) || string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(userSurname))
            {
                MessageBox.Show("Please select a file and enter your name and surname.");
                return;
            }

            try
            {
                // Generate ECDSA keys
                using (ECDsa ecdsa = ECDsa.Create(ECCurve.NamedCurves.nistP256))
                {
                    // Load the document
                    byte[] documentBytes = File.ReadAllBytes(filePath);

                    // Sign the document
                    byte[] signature = ecdsa.SignData(documentBytes, HashAlgorithmName.SHA256);

                    // Create PDF document with signature
                    string signedPdfPath = Path.ChangeExtension(filePath, ".pdf");
                    using (PdfWriter writer = new PdfWriter(signedPdfPath))
                    {
                        using (PdfDocument pdf = new PdfDocument(writer))
                        {
                            Document document = new Document(pdf);
                            document.Add(new Paragraph("Signed Document"));
                            document.Add(new Paragraph($"Signed by: {userName} {userSurname}"));
                            document.Add(new Paragraph($"Signature: {Convert.ToBase64String(signature)}"));
                        }
                    }

                    // Save the signature file
                    string signatureFilePath = Path.ChangeExtension(filePath, ".p7s");
                    using (StreamWriter writer = new StreamWriter(signatureFilePath))
                    {
                        writer.WriteLine($"Signature: {Convert.ToBase64String(signature)}");
                        writer.WriteLine($"Certificate: {Convert.ToBase64String(ecdsa.ExportParameters(false).D)}");
                    }

                    MessageBox.Show("Document signed successfully!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error signing the document: {ex.Message}");
            }
        }

        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {
            userName = nameTextBox.Text;
        }

        private void surnameTextBox_TextChanged(object sender, EventArgs e)
        {
            userSurname = surnameTextBox.Text;
        }
    }
}
