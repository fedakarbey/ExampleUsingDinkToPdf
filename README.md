# 📑 DinkToPdf ile PDF Rapor Generatörü API

Bu proje, **DinkToPdf** kütüphanesinin **.NET Core** ile nasıl kullanılacağını göstermek amacıyla geliştirilmiş bir örnek API'dir. API, HTML şablonlarından dinamik olarak PDF raporları oluşturmanıza olanak tanır. Müşteri bilgileri gibi dinamik verileri şablonlarla birleştirerek özelleştirilebilir raporlar üretilir.

---

## 🚀 Proje Amacı
**DinkToPdf** kütüphanesini kullanarak HTML formatındaki verileri PDF'e dönüştürme işleminin nasıl yapılacağını göstermek. Bu proje, bu kütüphanenin temel kullanımını anlamanızı ve kendi projelerinizde nasıl entegre edebileceğinizi öğrenmenizi sağlar.

---

## ⚙️ Özellikler
- **HTML Şablonları ile PDF Raporları**: Dinamik HTML şablonları kullanarak PDF raporları oluşturun.
- **Müşteri Bilgileri ile Dinamik İçerik**: Kullanıcı tarafından sağlanan müşteri bilgileri ile raporları özelleştirin.
- **DinkToPdf Kütüphanesi Entegrasyonu**: DinkToPdf kullanarak HTML'den PDF dönüşümü.
- **Kolay Kullanım**: Basit API endpoint'leri ile hızlıca PDF raporları oluşturun.

---

## 🔧 Gereksinimler
- **.NET 5.0 veya daha yeni bir sürüm** 🚀
- **DinkToPdf kütüphanesi** (proje içerisinde entegre edilmiştir)
- **Visual Studio veya Visual Studio Code** (Tercihe bağlı)

---

## 📥 Kurulum

### 1. Projeyi Klonlayın
İlk olarak projeyi yerel bilgisayarınıza klonlayın:

```bash
git clone https://github.com/fedakarbey/ExampleUsingDinkToPdf.git
```

### 2. Bağımlılıkları Yükleyin
Projenin kök dizininde, gerekli bağımlılıkları yüklemek için aşağıdaki komutu çalıştırın:

```bash
dotnet restore
```

### 3. Uygulamayı Çalıştırın
Projeyi çalıştırmak için şu komutu kullanabilirsiniz:

```bash
dotnet run
```

API, varsayılan olarak **https://localhost:5137** adresinde çalışacaktır. 🌐

---

## 📝 Kullanım

### PDF Raporu Oluşturma
PDF raporu oluşturmak için aşağıdaki JSON formatında bir POST isteği gönderin:

**Endpoint:**

```bash
POST /api/pdf/generate
```

**Örnek JSON İsteği:**

```json
{
    "TemplateName": "ReportTemplate",
    "ReportTitle": "Müşteri Raporu",
    "ReportDate": "2025-01-19",
    "CustomerInfo": [
        { "CustomerName": "Ahmet Yılmaz", "Amount": 2500.5, "Status": "Ödeme Bekliyor" },
        { "CustomerName": "Mehmet Demir", "Amount": 3500.75, "Status": "Ödendi" }
    ]
}
```

Bu istek, **ReportTemplate.html** şablonuna göre bir PDF dosyası oluşturur ve çıktıyı döndürür.

---

## 📄 Şablon Yapısı

Proje, `Templates/` klasöründe bir HTML şablonu ve `Styles/` klasöründe bir CSS dosyası içermektedir. Bu şablonlar, PDF raporunun içeriği ve görünümü için kullanılır.

- **ReportTemplate.html**: HTML şablonu, kullanıcı verisiyle dinamik olarak doldurulur.
- **template-style.css**: PDF'nin stilini belirleyen CSS dosyasıdır.

---

## 📄 Lisans
Bu proje MIT Lisansı altında lisanslanmıştır. Detaylar için **LICENSE** dosyasına bakabilirsiniz.

---

## 🤝 Katkıda Bulunma
Bu projeye katkıda bulunmak isterseniz, lütfen bir pull request (PR) gönderin. Yeni özellikler ekleyebilir, hataları düzeltebilir veya belgeleri geliştirebilirsiniz. 🔧

