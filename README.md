[See this text in Ukrainian 🇺🇦](https://github.com/FullyRealist/SecureVideoAppECDH/blob/main/README_ua.md)
# Digital Signature App
### Overview
**Digital Signature App** is a Windows Forms application developed in C# (.NET Framework 4.7.2) that demonstrates the process of creating digital signatures for documents using the **ECDSA (Elliptic Curve Digital Signature Algorithm)** cryptographic algorithm.

The application allows users to:

* Select a Microsoft Word document (`.doc` or `.docx`)
* Enter personal information (name and surname)
* Generate an ECDSA digital signature
* Create a PDF document containing signature information
* Export signature data into a `.p7s` file

> This project was created for educational and research purposes to demonstrate the principles of digital signatures and document integrity verification.

---

### 📋 Features

* ECDSA signature generation using the NIST P-256 curve
* SHA-256 hashing algorithm
* Simple Windows Forms graphical interface
* PDF generation with embedded signature information
* Signature export in `.p7s` format
* User identity information included in the generated document

---

### 🛠 Technologies Used

* C#
* .NET Framework 4.7.2
* Windows Forms
* ECDSA Cryptography
* SHA-256
* iText 8
* Bouncy Castle

---

### 🧭 Project Structure

```text
DigitalSignatureApp/
│
├── MainForm.cs
├── MainForm.Designer.cs
├── Program.cs
├── App.config
├── DigitalSignatureApp.csproj
│
├── Properties/
│   ├── AssemblyInfo.cs
│   ├── Resources.resx
│   └── Settings.settings
│
└── packages/
```

---

### 💡 How It Works

1. The user selects a Word document.
2. The user enters their name and surname.
3. The application generates an ECDSA key pair.
4. The selected document is hashed using SHA-256.
5. The document hash is digitally signed.
6. A PDF file is created containing:
   * Signer's information
   * Generated signature
7. A `.p7s` file containing signature data is exported.

---

### 💾 Installation

#### Requirements

* Windows 10/11
* .NET Framework 4.7.2
* Visual Studio 2019 or newer

#### 🚀 Build

```bash
git clone https://github.com/FullyRealist/DigitalSignatureApp.git
```

Open:

```text
DigitalSignatureApp.sln
```

Restore NuGet packages and build the solution.

---

### 🔁 Dependencies

* iText 8.0.3
* Portable.BouncyCastle 1.9.0
* Newtonsoft.Json 13.0.1

---

### ⚠️ Disclaimer

This project is intended for educational purposes only.

The implementation demonstrates digital signing concepts but should not be considered a production-ready electronic signature solution. Additional certificate management, secure key storage, and signature validation mechanisms are required for real-world applications.

---
© 2025. Odesa National Maritime University.
