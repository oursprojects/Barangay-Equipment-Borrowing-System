# Barangay Equipment Borrowing System

A comprehensive Windows Forms MDI application built with **VB.NET 2022** and **.NET 8.0** for managing equipment borrowing transactions in a barangay setting. This system provides a complete solution for tracking equipment inventory, borrower information, and borrowing/returning transactions.

---

## 👥 Developers

This project was developed by:

- **Mike Ryno Santiago**
- **Jestoni Flores**
- **Deejay Angelo**

**Project**: IT 313 Final Group Project  
**Academic Year**: 2024

---

## ✨ Features

### Core Functionality
- ✅ **Complete CRUD Operations**: Full Create, Read, Update, Delete functionality for Equipment, Borrowers, and Borrowing transactions
- ✅ **Database Transactions**: Multi-step operations wrapped in database transactions with automatic rollback on errors
- ✅ **Advanced Search & Filtering**: Multi-field search with date ranges, status filters, and custom sorting options
- ✅ **Print Functionality**: Print preview and printing for lists and reports using PrintDocument
- ✅ **Stock Management**: Automatic stock updates when items are borrowed or returned
- ✅ **Input Validation**: Comprehensive validation with required fields, data type checking, and business rules
- ✅ **Audit Trail**: CreatedAt and UpdatedAt timestamps on all tables for tracking changes

### User Interface
- 🎨 **Modern UI Design**: Clean, professional interface with consistent Segoe UI fonts
- 📱 **MDI Application**: Multiple Document Interface for managing multiple forms simultaneously
- 🖥️ **Welcome Screen**: Attractive welcome screen with quick access to main features
- 📊 **DataGridView Integration**: Optimized grid views with sorting and filtering capabilities
- 🎯 **Status Bar**: Real-time database connection status and date/time display
- 📋 **About Dialog**: Professional about dialog with developer credits

### Transaction Management
- 🔄 **Multi-Item Borrowing**: Support for borrowing multiple equipment items in a single transaction
- 📦 **Partial Returns**: Items can be returned in multiple batches (partial returns)
- ⚡ **Stock Synchronization**: Real-time stock updates when items are borrowed or returned
- 🔒 **Data Integrity**: All operations use database transactions to ensure data consistency

---

## 🗄️ Database

The system uses **Microsoft Access** (.accdb) database format for simplicity and ease of deployment.

### Database Schema

#### Master Tables
- **Equipment**: Equipment items (chairs, tents, tables, etc.)
  - EquipmentID (Primary Key, AutoNumber)
  - ItemName, Category, Description
  - Stock, Unit
  - CreatedAt, UpdatedAt

- **Borrowers**: Borrower/resident information
  - BorrowerID (Primary Key, AutoNumber)
  - FullName, ContactNo, Address, Email
  - CreatedAt, UpdatedAt

#### Transaction Tables
- **Borrowings**: Borrowing transaction headers
  - BorrowingID (Primary Key, AutoNumber)
  - BorrowerID (Foreign Key → Borrowers)
  - BorrowDate, ExpectedReturnDate, ReturnDate
  - Status (Active, Returned, Overdue)
  - Notes, CreatedAt, UpdatedAt

- **BorrowingItems**: Individual items in each borrowing transaction
  - BorrowingItemID (Primary Key, AutoNumber)
  - BorrowingID (Foreign Key → Borrowings)
  - EquipmentID (Foreign Key → Equipment)
  - Quantity, ReturnedQuantity
  - CreatedAt, UpdatedAt

### Relationships
- Borrowings → Borrowers (One-to-Many)
- BorrowingItems → Borrowings (One-to-Many)
- BorrowingItems → Equipment (Many-to-One)

---

## 🚀 Getting Started

### Prerequisites

- **Visual Studio 2022** (Community, Professional, or Enterprise)
- **.NET 8.0 SDK** (Windows Desktop workload)
- **Microsoft Access Database Engine 2016 Redistributable** (ACE OLE DB)
  - Download from: https://www.microsoft.com/en-us/download/details.aspx?id=54920
  - Choose x64 or x86 version based on your system

### Installation Steps

1. **Clone or Download** this repository
2. **Open** the solution in Visual Studio 2022
3. **Restore NuGet packages** (if needed)
4. **Build** the solution (Build → Build Solution)
5. **Follow** the detailed setup instructions in `SETUP_INSTRUCTIONS.txt`

### Quick Setup

1. Install Microsoft Access Database Engine (see SETUP_INSTRUCTIONS.txt)
2. Build the application
3. Create `Data` folder in `bin\Debug\net8.0-windows\`
4. Create `BarangayEquipment.accdb` in the Data folder
5. Run the SQL scripts from the `Database` folder OR let the application auto-seed on first run

**Note**: The application will automatically seed sample data on first run if the database is empty.

---

## 📁 Project Structure

```
BarangayEquipmentBorrowing/
│
├── Forms/
│   ├── Form1.vb                    # Welcome Screen
│   ├── Form1.Designer.vb
│   ├── FrmMain.vb                  # MDI Parent Form
│   ├── FrmMain.Designer.vb
│   ├── FrmAbout.vb                 # About Dialog
│   ├── FrmAbout.Designer.vb
│   ├── FrmEquipmentList.vb         # Equipment List Form
│   ├── FrmEquipmentEdit.vb         # Equipment Add/Edit Form
│   ├── FrmBorrowerList.vb          # Borrower List Form
│   ├── FrmBorrowerEdit.vb          # Borrower Add/Edit Form
│   ├── FrmBorrowingList.vb         # Borrowing Transaction List
│   ├── FrmBorrowingEdit.vb         # Borrowing Add/Edit Form
│   └── FrmBorrowingReturn.vb       # Return Equipment Form
│
├── Modules/
│   ├── DataAccess.vb               # Data Access Layer (ADO.NET)
│   └── DatabaseSeeder.vb           # Auto-seed database module
│
├── Database/
│   ├── create_tables.sql           # Database schema (CREATE TABLE statements)
│   ├── create_tables_manual.txt    # Manual setup instructions
│   └── seed.sql                    # Sample data (optional - auto-seeded now)
│
├── My Project/
│   ├── Application.Designer.vb     # Application configuration
│   └── Application.myapp           # Application settings
│
├── README.md                        # This file
├── SETUP_INSTRUCTIONS.txt          # Detailed setup guide
└── BarangayEquipmentBorrowing.vbproj
```

---

## ⚙️ Configuration

### Database Connection

The connection string is configured in `Modules/DataAccess.vb`. By default, it looks for the database at:

```
[Application Directory]\Data\BarangayEquipment.accdb
```

The application automatically creates the `Data` folder if it doesn't exist. You can modify the connection string in the `GetConnectionString()` function if you need a different location.

### Connection String Format

```vb
Provider=Microsoft.ACE.OLEDB.12.0;Data Source=[Path];Persist Security Info=False;
```

---

## 📖 Usage Guide

### Application Startup

1. **Welcome Screen**: The application starts with an attractive welcome screen
2. **Start System**: Click "Start System" to open the main application window
3. **Exit**: Click "Exit" to close the application

### Main Menu

- **File** → Exit: Close the main application and return to welcome screen
- **Maintenance** → Equipment/Borrowers: Manage master data
- **Transactions** → Borrowings: Manage borrowing transactions
- **Window** → Layout options for MDI child windows (Cascade, Tile Horizontal, Tile Vertical)
- **Help** → About: View application information and developer credits

### Equipment Maintenance

**Features:**
- Add new equipment items with stock quantities
- Edit existing equipment information
- Delete equipment (with validation - prevents deletion if used in transactions)
- Search by item name and category
- Sort by various fields
- Print equipment list with PrintPreviewDialog

**Fields:**
- Item Name* (Required)
- Category
- Description
- Stock* (Required, Integer)
- Unit

### Borrowers Maintenance

**Features:**
- Add new borrowers/residents
- Edit borrower information
- Delete borrowers (with validation)
- Search by full name
- Sort by name or other fields
- Print borrowers list

**Fields:**
- Full Name* (Required)
- Contact Number
- Address
- Email

### Borrowing Transactions

**Features:**
- Create new borrowing transactions with multiple items
- Edit active transactions (cannot edit returned transactions)
- Return items (partial or full return supported)
- Search by borrower name, date range, and status
- Sort by various fields (date, borrower, status)
- Print borrowing reports
- **Transaction Support**: All operations use database transactions to ensure data integrity

**Transaction Flow:**
1. Select borrower and set dates
2. Add equipment items with quantities
3. System validates stock availability
4. Save transaction (uses database transaction - all or nothing)
5. Stock automatically reduced
6. Return items when equipment is returned
7. Stock automatically restored

---

## 🔧 Technical Details

### Technology Stack
- **Language**: Visual Basic .NET
- **Framework**: .NET 8.0
- **UI Framework**: Windows Forms
- **Database**: Microsoft Access (ACE OLE DB)
- **Data Access**: ADO.NET (System.Data.OleDb)

### Key Design Patterns
- **Data Access Layer**: Separated data access logic in `DataAccess.vb` module
- **MDI Architecture**: Multiple Document Interface for managing multiple forms
- **Transaction Management**: Database transactions for multi-step operations
- **Parameterized Queries**: All SQL queries use parameters to prevent SQL injection

### Code Quality
- ✅ **Option Strict On**: Type-safe code with explicit type conversions
- ✅ **Option Explicit On**: All variables must be declared
- ✅ **Error Handling**: Try-catch blocks with user-friendly error messages
- ✅ **Code Comments**: Well-documented code with XML comments where appropriate

---

## 🧪 Testing Checklist

Before demonstration, ensure the following are tested:

### CRUD Operations
- [ ] Add new equipment item
- [ ] Edit existing equipment item
- [ ] Delete equipment item (with validation)
- [ ] Add new borrower
- [ ] Edit existing borrower
- [ ] Delete borrower (with validation)
- [ ] Create new borrowing transaction with multiple items
- [ ] Edit active borrowing transaction
- [ ] Delete borrowing transaction

### Search & Sort
- [ ] Search equipment by name and category
- [ ] Search borrowers by name
- [ ] Search borrowings by borrower name, date range, and status
- [ ] Sort by various fields (verify order changes correctly)

### Transaction Management
- [ ] Create borrowing with multiple items - verify stock updates
- [ ] Transaction rollback test: Force an error and verify no partial writes
- [ ] Return items (partial return) - verify stock updates correctly
- [ ] Return items (full return) - verify status changes to "Returned"

### Print Functionality
- [ ] Print equipment list (verify pagination works)
- [ ] Print borrowers list
- [ ] Print borrowing reports

### System Integration
- [ ] Database connection on clean installation
- [ ] Auto-seed on first run (verify data is inserted)
- [ ] Welcome screen displays correctly
- [ ] About dialog shows developer names
- [ ] Status bar shows correct database status

---

## 🐛 Troubleshooting

### Database Connection Issues

**Error**: "Database connection failed"

**Solutions:**
1. ✅ Verify Microsoft Access Database Engine is installed
   - Check Control Panel → Programs
   - Download from: https://www.microsoft.com/en-us/download/details.aspx?id=54920

2. ✅ Check database file location
   - Path: `bin\Debug\net8.0-windows\Data\BarangayEquipment.accdb`
   - Ensure Data folder exists
   - Verify database file exists

3. ✅ Verify file permissions
   - Ensure read/write permissions on Data folder
   - Run application as administrator if needed

4. ✅ Check if database is locked
   - Close Microsoft Access if database is open
   - Ensure no other process is using the database

5. ✅ Verify connection string
   - Check `Modules/DataAccess.vb`
   - Ensure path is correct

### Common Errors

**"Column named X cannot be found"**
- Ensure database tables are created correctly
- Verify column names match the schema
- Check for NULL value handling in code

**"OleDbParameter is already contained"**
- This has been fixed in the code - parameters are now cloned for each command
- Ensure you're using the latest code version

**Application doesn't start**
- Verify Form1 is set as startup form in Application.myapp
- Check for any compilation errors
- Ensure all dependencies are installed

---

## 📝 Notes

### Security
- ✅ All SQL queries use **parameterized queries** to prevent SQL injection attacks
- ✅ Input validation prevents invalid data entry
- ✅ Database transactions ensure data integrity

### Performance
- ✅ Efficient database queries with proper indexing
- ✅ Connection pooling through ADO.NET
- ✅ Optimized DataGridView display with manual column setup

### Best Practices
- ✅ Separation of concerns (Data Access Layer)
- ✅ Error handling with user-friendly messages
- ✅ Code reusability through module functions
- ✅ Consistent naming conventions
- ✅ Professional UI/UX design

---

## 📚 Additional Resources

- **Microsoft Access Database Engine**: https://www.microsoft.com/en-us/download/details.aspx?id=54920
- **.NET 8.0 Documentation**: https://learn.microsoft.com/dotnet/
- **ADO.NET Guide**: https://learn.microsoft.com/dotnet/framework/data/adonet/
- **Windows Forms Documentation**: https://learn.microsoft.com/dotnet/desktop/winforms/

---

## 📄 License

This project was created for **IT 313 Final Group Project** as part of academic coursework.

**Developed by:**
- Mike Ryno Santiago
- Jestoni Flores
- Deejay Angelo

---

## 📞 Support

For issues or questions:
1. Check the `SETUP_INSTRUCTIONS.txt` file for detailed setup guidance
2. Review the Troubleshooting section above
3. Verify all prerequisites are installed correctly
4. Check database file location and permissions

---

**Version**: 1.0.0  
**Last Updated**: 2024  
**Framework**: .NET 8.0  
**Database**: Microsoft Access (.accdb)
