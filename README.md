# 🏨 Hotel Booking System in C\#

![C#](https://img.shields.io/badge/Language-C%23-blue)
![Platform](https://img.shields.io/badge/Platform-Console-yellow)
---

## Description

A **C# console-based hotel booking system** that allows users to manage clients, rooms, reservations, and payments. The system calculates total price, applies reductions for card payments, and provides a styled console interface.

---

## Features ✨

* ✅ Add and manage clients with identity verification.
* ✅ View available rooms with type and price.
* ✅ Create reservations with check-in and check-out dates.
* ✅ Calculate total price based on the number of nights.
* ✅ Apply a 5% discount for card payments.
* ✅ Styled console output with colors and emojis for better UX.
* ✅ Display reservation summary and final payment amount.

---

## Installation 💻


## Usage 📝

1. Run the application.
2. View the available rooms.
3. Enter client details: Name, Email, Phone, Identity card status.
4. Enter reservation details: Room number, type, price, check-in and check-out dates.
5. Enter payment type (e.g., `CarteBancaire` for 5% discount).
6. See a summary of the reservation, reduction (if any), and total amount to pay.

---

## Example Output 📺

```
╔════════════════════════════════════════╗
║      🏨 Welcome to the Booking System ║
╚════════════════════════════════════════╝

Available Rooms:
🔹 Room Number: 101 | Type: Single | Price per night: 700DH
🔹 Room Number: 102 | Type: Double | Price per night: 1500DH
🔹 Room Number: 103 | Type: Suite | Price per night: 10000DH

Please enter your details:
Name: Mar
Email: Mar@example.com
Phone Number: 00000000
Do you have an identity card? (true/false): true

Please enter your reservation details:
Room Type: Single
Room Number: 101
Price per night: 700
Check-in Date (yyyy-MM-dd): 2025-09-16
Check-out Date (yyyy-MM-dd): 2025-09-18

📄 Reservation Summary:
You selected the Room:101--Single--700 DH--2025-09-16---2025-09-18

Payment Type: CarteBancaire
💰 Reduction Amount: 70 DH
🧾 Total Amount to Pay: 1330 DH

Thank you for booking with us! ✅
``

## Author ✨

**Marouan El Yassini / ELY**
