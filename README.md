# PCPartPicker Links Scraper 🚀

## 📌 Overview
This **C# console application** is designed to **scrape product links** from the CPU section of [PCPartPicker](https://pcpartpicker.com/products/cpu/) using Selenium WebDriver with Chrome. The extracted links are saved into a text file (`cpujsonlinks.txt`) for further use.

## ✨ Features
✔ **Automated Web Scraping** with Selenium WebDriver.
✔ **Bypasses Restrictions** using Browsec VPN Extension.
✔ **Handles Pagination** to extract all available product links.
✔ **Exports Data to a File** (`cpujsonlinks.txt`) for easy access.

---

## ⚙ Prerequisites
Before running this script, ensure you have the following installed:

🔹 **Google Chrome** (latest version recommended).
🔹 **Chrome WebDriver** matching your Chrome version.
🔹 **Selenium WebDriver NuGet Packages**:
  - `OpenQA.Selenium`
  - `OpenQA.Selenium.Chrome`
🔹 **Browsec VPN Chrome Extension** installed at:
```
C:\Users\YOURUSERNAME\AppData\Local\Google\Chrome\User Data\Default\Extensions\omghfjlpggmjjaagoclmmobgdodcjboh\3.88.4_0
```
*(Ensure the path is correct for your system!)*

---

## 🚀 Installation & Setup
1️⃣ Clone or download the repository containing the scraper script.
2️⃣ Ensure that **Chrome WebDriver** is in your system's **PATH** or specify its location in the script.
3️⃣ Install required Selenium dependencies using **NuGet Package Manager**.

---

## ▶️ How to Use
1️⃣ Run the **C# console application**.
2️⃣ The script will **open Chrome**, navigate to **PCPartPicker CPU listings**, and extract **product links**.
3️⃣ The extracted links will be **saved in `cpujsonlinks.txt`**.
4️⃣ The console will display the **progress and extracted URLs** in real-time.

---

## 📂 Output File
The script generates a file named `cpujsonlinks.txt` in the application directory. This file contains **one product URL per line**, which can later be used for extracting product details.

### 🔍 Example Output (`cpujsonlinks.txt`):
```
https://pcpartpicker.com/product/xyz123/amd-ryzen-7-5800x
https://pcpartpicker.com/product/abc456/intel-core-i7-12700k
...
```

---

## 🔧 Extending the Scraper
### 🖥 Scraping Other Categories
You can modify the `baseUrl` variable in the script to target different product categories:
- **GPUs**: `https://pcpartpicker.com/products/video-card/`
- **Motherboards**: `https://pcpartpicker.com/products/motherboard/`

Also, update the **CSS selectors** accordingly if needed.

### 🏗 Extracting Product Details
Once you have product links, another scraper can be used to extract **detailed specifications**, such as:
✔ **Product Name**
✔ **Core & Thread Count**
✔ **Base Clock Speed & TDP**
✔ **Price, Availability & Ratings**
✔ **Product Images & Descriptions**

This requires an additional Selenium script to navigate each product page and collect data.

---

## ⚠️ Important Notes
⚡ **Includes a delay** between page navigations to **prevent detection**.
⚡ Ensure that **VPN is correctly set up** to avoid **IP bans**.
⚡ You may need to **update ChromeDriver** if PCPartPicker changes its structure.

---

## 📜 License
This project is intended for **educational and personal use**. Please use it responsibly. ✅

