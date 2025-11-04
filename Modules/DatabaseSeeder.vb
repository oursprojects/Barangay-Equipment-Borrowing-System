Imports System.Data
Imports System.Data.OleDb
Imports System.Windows.Forms

''' <summary>
''' Database Seeder Module
''' Seeds the database with initial data if tables are empty
''' </summary>
Module DatabaseSeeder

    ''' <summary>
    ''' Seeds the database with initial data if needed
    ''' </summary>
    Public Sub SeedDatabase()
        Try
            ' Check if Equipment table has data
            Dim equipmentCount As Integer = CInt(DataAccess.ExecScalar("SELECT COUNT(*) FROM Equipment"))
            
            If equipmentCount = 0 Then
                SeedEquipment()
                SeedBorrowers()
                SeedBorrowings()
                MessageBox.Show("Database seeded successfully with initial data.", "Database Setup", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            ' Silently fail - database might not exist yet or other issues
            ' User can still use the system, they just need to add data manually
        End Try
    End Sub

    Private Sub SeedEquipment()
        Dim equipmentData As New List(Of EquipmentSeed) From {
            New EquipmentSeed("Folding Chair", "Furniture", "Plastic folding chair, white", 50, "pcs"),
            New EquipmentSeed("Folding Chair", "Furniture", "Plastic folding chair, blue", 30, "pcs"),
            New EquipmentSeed("Round Table", "Furniture", "8-seater round table", 15, "pcs"),
            New EquipmentSeed("Rectangular Table", "Furniture", "10-seater rectangular table", 20, "pcs"),
            New EquipmentSeed("10x10 Tent", "Tent", "10x10 feet event tent, blue", 8, "pcs"),
            New EquipmentSeed("10x20 Tent", "Tent", "10x20 feet event tent, blue", 5, "pcs"),
            New EquipmentSeed("Sound System", "Electronics", "Complete PA system with 2 speakers", 2, "set"),
            New EquipmentSeed("Microphone", "Electronics", "Wireless microphone", 4, "pcs"),
            New EquipmentSeed("Generator", "Equipment", "5KVA portable generator", 3, "pcs"),
            New EquipmentSeed("Extension Cord", "Electronics", "50-meter extension cord", 10, "pcs"),
            New EquipmentSeed("Spotlight", "Electronics", "Portable spotlight", 6, "pcs"),
            New EquipmentSeed("Barricade", "Safety", "Metal barricade, orange", 25, "pcs"),
            New EquipmentSeed("Traffic Cone", "Safety", "Orange traffic cone", 40, "pcs"),
            New EquipmentSeed("Rope", "General", "Nylon rope, 50 meters", 15, "pcs"),
            New EquipmentSeed("Tarpaulin", "General", "Waterproof tarpaulin, 10x12", 12, "pcs"),
            New EquipmentSeed("Cooler", "General", "Large ice cooler", 5, "pcs"),
            New EquipmentSeed("Water Dispenser", "General", "Electric water dispenser", 3, "pcs"),
            New EquipmentSeed("Step Ladder", "Equipment", "5-step aluminum ladder", 4, "pcs"),
            New EquipmentSeed("Tool Box", "Equipment", "Basic tool set", 6, "pcs"),
            New EquipmentSeed("First Aid Kit", "Safety", "Complete first aid kit", 8, "pcs"),
            New EquipmentSeed("Tarp Cover", "General", "Heavy duty tarp cover", 10, "pcs"),
            New EquipmentSeed("Portable Fan", "Electronics", "Standing electric fan", 7, "pcs")
        }

        For Each item In equipmentData
            Dim sql As String = "INSERT INTO Equipment (ItemName, Category, Description, Stock, Unit, CreatedAt, UpdatedAt) VALUES (?, ?, ?, ?, ?, NOW(), NOW())"
            Dim params As New List(Of OleDb.OleDbParameter) From {
                New OleDb.OleDbParameter() With {.Value = item.ItemName},
                New OleDb.OleDbParameter() With {.Value = item.Category},
                New OleDb.OleDbParameter() With {.Value = item.Description},
                New OleDb.OleDbParameter() With {.Value = item.Stock},
                New OleDb.OleDbParameter() With {.Value = item.Unit}
            }
            DataAccess.ExecNonQuery(sql, params)
        Next
    End Sub

    Private Sub SeedBorrowers()
        Dim borrowerData As New List(Of BorrowerSeed) From {
            New BorrowerSeed("Juan Dela Cruz", "09171234567", "123 Rizal Street, Barangay Centro", "juan.delacruz@email.com"),
            New BorrowerSeed("Maria Santos", "09223456789", "456 Mabini Avenue, Barangay Centro", "maria.santos@email.com"),
            New BorrowerSeed("Pedro Garcia", "09334567890", "789 Bonifacio Street, Barangay Norte", "pedro.garcia@email.com"),
            New BorrowerSeed("Ana Lopez", "09445678901", "321 Aguinaldo Road, Barangay Sur", "ana.lopez@email.com"),
            New BorrowerSeed("Carlos Rodriguez", "09556789012", "654 Quezon Boulevard, Barangay Este", "carlos.rodriguez@email.com"),
            New BorrowerSeed("Rosa Martinez", "09667890123", "987 Roxas Street, Barangay Oeste", "rosa.martinez@email.com"),
            New BorrowerSeed("Jose Fernandez", "09778901234", "147 Lapu-Lapu Avenue, Barangay Norte", "jose.fernandez@email.com"),
            New BorrowerSeed("Carmen Reyes", "09889012345", "258 Paterno Street, Barangay Sur", "carmen.reyes@email.com"),
            New BorrowerSeed("Antonio Cruz", "09990123456", "369 Luna Road, Barangay Centro", "antonio.cruz@email.com"),
            New BorrowerSeed("Lourdes Torres", "09101234567", "741 Magsaysay Boulevard, Barangay Norte", "lourdes.torres@email.com"),
            New BorrowerSeed("Roberto Ramos", "09212345678", "852 Gomez Street, Barangay Este", "roberto.ramos@email.com"),
            New BorrowerSeed("Sofia Villanueva", "09323456789", "963 Del Pilar Avenue, Barangay Oeste", "sofia.villanueva@email.com"),
            New BorrowerSeed("Ricardo Mendoza", "09434567890", "159 Rizal Street, Barangay Sur", "ricardo.mendoza@email.com"),
            New BorrowerSeed("Elena Castro", "09545678901", "357 Mabini Avenue, Barangay Centro", "elena.castro@email.com"),
            New BorrowerSeed("Felipe Aquino", "09656789012", "468 Bonifacio Street, Barangay Norte", "felipe.aquino@email.com"),
            New BorrowerSeed("Isabela De Leon", "09767890123", "579 Aguinaldo Road, Barangay Este", "isabela.deleon@email.com"),
            New BorrowerSeed("Manuel Bautista", "09878901234", "680 Quezon Boulevard, Barangay Oeste", "manuel.bautista@email.com"),
            New BorrowerSeed("Teresa Morales", "09989012345", "791 Roxas Street, Barangay Sur", "teresa.morales@email.com"),
            New BorrowerSeed("Alfredo Gutierrez", "09190123456", "802 Lapu-Lapu Avenue, Barangay Centro", "alfredo.gutierrez@email.com"),
            New BorrowerSeed("Consuelo Herrera", "09201234567", "913 Paterno Street, Barangay Norte", "consuelo.herrera@email.com"),
            New BorrowerSeed("Miguel Ocampo", "09312345678", "124 Luna Road, Barangay Este", "miguel.ocampo@email.com"),
            New BorrowerSeed("Rosario Alvarado", "09423456789", "235 Magsaysay Boulevard, Barangay Oeste", "rosario.alvarado@email.com")
        }

        For Each borrower In borrowerData
            Dim sql As String = "INSERT INTO Borrowers (FullName, ContactNo, Address, Email, CreatedAt, UpdatedAt) VALUES (?, ?, ?, ?, NOW(), NOW())"
            Dim params As New List(Of OleDb.OleDbParameter) From {
                New OleDb.OleDbParameter() With {.Value = borrower.FullName},
                New OleDb.OleDbParameter() With {.Value = borrower.ContactNo},
                New OleDb.OleDbParameter() With {.Value = borrower.Address},
                New OleDb.OleDbParameter() With {.Value = borrower.Email}
            }
            DataAccess.ExecNonQuery(sql, params)
        Next
    End Sub

    Private Sub SeedBorrowings()
        ' Get borrower IDs (assuming they're sequential starting from 1)
        ' Get equipment IDs (assuming they're sequential starting from 1)

        Dim borrowingData As New List(Of BorrowingSeed) From {
            New BorrowingSeed(1, New Date(2024, 1, 15), New Date(2024, 1, 17), New Date(2024, 1, 17), "Returned", "Community meeting"),
            New BorrowingSeed(2, New Date(2024, 1, 18), New Date(2024, 1, 20), New Date(2024, 1, 20), "Returned", "Birthday party"),
            New BorrowingSeed(3, New Date(2024, 1, 20), New Date(2024, 1, 22), Nothing, "Active", "Wedding reception"),
            New BorrowingSeed(4, New Date(2024, 1, 22), New Date(2024, 1, 24), New Date(2024, 1, 23), "Returned", "Family gathering"),
            New BorrowingSeed(5, New Date(2024, 1, 25), New Date(2024, 1, 27), Nothing, "Active", "Barangay fiesta"),
            New BorrowingSeed(6, New Date(2024, 2, 1), New Date(2024, 2, 3), New Date(2024, 2, 3), "Returned", "School event"),
            New BorrowingSeed(7, New Date(2024, 2, 5), New Date(2024, 2, 7), New Date(2024, 2, 8), "Returned", "Delayed return"),
            New BorrowingSeed(8, New Date(2024, 2, 8), New Date(2024, 2, 10), Nothing, "Active", "Medical mission"),
            New BorrowingSeed(9, New Date(2024, 2, 12), New Date(2024, 2, 14), New Date(2024, 2, 14), "Returned", "Valentine event"),
            New BorrowingSeed(10, New Date(2024, 2, 15), New Date(2024, 2, 17), New Date(2024, 2, 16), "Returned", "Community cleanup"),
            New BorrowingSeed(11, New Date(2024, 2, 18), New Date(2024, 2, 20), Nothing, "Active", "Sports event"),
            New BorrowingSeed(12, New Date(2024, 2, 20), New Date(2024, 2, 22), New Date(2024, 2, 22), "Returned", "Religious gathering"),
            New BorrowingSeed(13, New Date(2024, 2, 25), New Date(2024, 2, 27), New Date(2024, 2, 27), "Returned", "Seminar"),
            New BorrowingSeed(14, New Date(2024, 3, 1), New Date(2024, 3, 3), Nothing, "Active", "Food distribution"),
            New BorrowingSeed(15, New Date(2024, 3, 5), New Date(2024, 3, 7), New Date(2024, 3, 6), "Returned", "Health fair"),
            New BorrowingSeed(16, New Date(2024, 3, 8), New Date(2024, 3, 10), New Date(2024, 3, 10), "Returned", "Cultural show"),
            New BorrowingSeed(17, New Date(2024, 3, 12), New Date(2024, 3, 14), Nothing, "Active", "Job fair"),
            New BorrowingSeed(18, New Date(2024, 3, 15), New Date(2024, 3, 17), New Date(2024, 3, 17), "Returned", "Cleanup drive"),
            New BorrowingSeed(19, New Date(2024, 3, 18), New Date(2024, 3, 20), New Date(2024, 3, 19), "Returned", "Early return"),
            New BorrowingSeed(20, New Date(2024, 3, 20), New Date(2024, 3, 22), Nothing, "Active", "Graduation ceremony"),
            New BorrowingSeed(1, New Date(2024, 3, 22), New Date(2024, 3, 24), New Date(2024, 3, 24), "Returned", "Second borrowing"),
            New BorrowingSeed(2, New Date(2024, 3, 25), New Date(2024, 3, 27), Nothing, "Active", "Anniversary celebration"),
            New BorrowingSeed(3, New Date(2024, 3, 28), New Date(2024, 3, 30), New Date(2024, 3, 30), "Returned", "Family reunion"),
            New BorrowingSeed(4, New Date(2024, 4, 1), New Date(2024, 4, 3), Nothing, "Active", "Easter event"),
            New BorrowingSeed(5, New Date(2024, 4, 5), New Date(2024, 4, 7), New Date(2024, 4, 7), "Returned", "Community meeting"),
            New BorrowingSeed(6, New Date(2024, 4, 8), New Date(2024, 4, 10), New Date(2024, 4, 9), "Returned", "School program"),
            New BorrowingSeed(7, New Date(2024, 4, 12), New Date(2024, 4, 14), Nothing, "Active", "Fundraising event"),
            New BorrowingSeed(8, New Date(2024, 4, 15), New Date(2024, 4, 17), New Date(2024, 4, 17), "Returned", "Health program"),
            New BorrowingSeed(9, New Date(2024, 4, 18), New Date(2024, 4, 20), Nothing, "Active", "Sports tournament"),
            New BorrowingSeed(10, New Date(2024, 4, 22), New Date(2024, 4, 24), New Date(2024, 4, 24), "Returned", "Community assembly")
        }

        ' Items data: (BorrowingID, EquipmentID, Quantity, ReturnedQuantity)
        Dim itemsData As New List(Of BorrowingItemSeed) From {
            New BorrowingItemSeed(1, 1, 20, 20), New BorrowingItemSeed(1, 5, 2, 2),
            New BorrowingItemSeed(2, 1, 15, 15), New BorrowingItemSeed(2, 3, 3, 3),
            New BorrowingItemSeed(3, 1, 30, 0), New BorrowingItemSeed(3, 4, 5, 0), New BorrowingItemSeed(3, 5, 3, 0),
            New BorrowingItemSeed(4, 2, 25, 25), New BorrowingItemSeed(4, 5, 1, 1),
            New BorrowingItemSeed(5, 1, 40, 0), New BorrowingItemSeed(5, 3, 8, 0), New BorrowingItemSeed(5, 5, 5, 0), New BorrowingItemSeed(5, 7, 1, 0),
            New BorrowingItemSeed(6, 1, 18, 18), New BorrowingItemSeed(6, 3, 4, 4),
            New BorrowingItemSeed(7, 2, 20, 20), New BorrowingItemSeed(7, 4, 3, 3), New BorrowingItemSeed(7, 6, 2, 2),
            New BorrowingItemSeed(8, 1, 25, 0), New BorrowingItemSeed(8, 5, 2, 0),
            New BorrowingItemSeed(9, 1, 12, 12), New BorrowingItemSeed(9, 3, 2, 2),
            New BorrowingItemSeed(10, 1, 15, 15), New BorrowingItemSeed(10, 12, 10, 10),
            New BorrowingItemSeed(11, 1, 20, 0), New BorrowingItemSeed(11, 3, 4, 0),
            New BorrowingItemSeed(12, 1, 18, 18), New BorrowingItemSeed(12, 5, 1, 1),
            New BorrowingItemSeed(13, 1, 22, 22), New BorrowingItemSeed(13, 3, 5, 5),
            New BorrowingItemSeed(14, 1, 30, 0), New BorrowingItemSeed(14, 4, 6, 0),
            New BorrowingItemSeed(15, 1, 15, 15), New BorrowingItemSeed(15, 5, 2, 2),
            New BorrowingItemSeed(16, 1, 20, 20), New BorrowingItemSeed(16, 3, 4, 4),
            New BorrowingItemSeed(17, 1, 25, 0), New BorrowingItemSeed(17, 5, 3, 0),
            New BorrowingItemSeed(18, 1, 18, 18), New BorrowingItemSeed(18, 12, 8, 8),
            New BorrowingItemSeed(19, 1, 16, 16), New BorrowingItemSeed(19, 3, 3, 3),
            New BorrowingItemSeed(20, 1, 35, 0), New BorrowingItemSeed(20, 3, 7, 0), New BorrowingItemSeed(20, 5, 4, 0),
            New BorrowingItemSeed(21, 1, 15, 15), New BorrowingItemSeed(21, 5, 1, 1),
            New BorrowingItemSeed(22, 1, 20, 0), New BorrowingItemSeed(22, 4, 4, 0),
            New BorrowingItemSeed(23, 1, 18, 18), New BorrowingItemSeed(23, 3, 3, 3),
            New BorrowingItemSeed(24, 1, 25, 0), New BorrowingItemSeed(24, 5, 2, 0),
            New BorrowingItemSeed(25, 1, 20, 20), New BorrowingItemSeed(25, 3, 4, 4),
            New BorrowingItemSeed(26, 1, 16, 16), New BorrowingItemSeed(26, 5, 1, 1),
            New BorrowingItemSeed(27, 1, 22, 0), New BorrowingItemSeed(27, 4, 5, 0),
            New BorrowingItemSeed(28, 1, 18, 18), New BorrowingItemSeed(28, 5, 2, 2),
            New BorrowingItemSeed(29, 1, 24, 0), New BorrowingItemSeed(29, 3, 5, 0),
            New BorrowingItemSeed(30, 1, 20, 20), New BorrowingItemSeed(30, 5, 1, 1)
        }

        ' Insert borrowings and get the IDs
        Dim borrowingIDs As New List(Of Integer)
        For Each borrowing In borrowingData
            Dim sql As String = "INSERT INTO Borrowings (BorrowerID, BorrowDate, ExpectedReturnDate, ActualReturnDate, Status, Notes, CreatedAt, UpdatedAt) VALUES (?, ?, ?, ?, ?, ?, NOW(), NOW())"
            Dim actualReturnValue As Object
            If borrowing.ActualReturnDate.HasValue Then
                actualReturnValue = borrowing.ActualReturnDate.Value
            Else
                actualReturnValue = DBNull.Value
            End If

            Dim params As New List(Of OleDb.OleDbParameter) From {
                New OleDb.OleDbParameter() With {.Value = borrowing.BorrowerID},
                New OleDb.OleDbParameter() With {.Value = borrowing.BorrowDate},
                New OleDb.OleDbParameter() With {.Value = borrowing.ExpectedReturnDate},
                New OleDb.OleDbParameter() With {.Value = actualReturnValue},
                New OleDb.OleDbParameter() With {.Value = borrowing.Status},
                New OleDb.OleDbParameter() With {.Value = borrowing.Notes}
            }

            ' Execute and get the new ID
            Dim connString As String = DataAccess.GetConnectionString()
            Using cn As New OleDb.OleDbConnection(connString)
                cn.Open()
                Using cmd As New OleDb.OleDbCommand(sql, cn)
                    For Each p In params
                        cmd.Parameters.Add(p)
                    Next
                    cmd.ExecuteNonQuery()
                    Using cmd2 As New OleDb.OleDbCommand("SELECT @@IDENTITY", cn)
                        Dim newID As Integer = CInt(cmd2.ExecuteScalar())
                        borrowingIDs.Add(newID)
                    End Using
                End Using
            End Using
        Next

        ' Insert items (map old borrowing IDs to new IDs)
        For i As Integer = 0 To itemsData.Count - 1
            Dim item = itemsData(i)
            Dim newBorrowingID As Integer = borrowingIDs(item.BorrowingID - 1) ' -1 because list is 0-indexed

            Dim sql As String = "INSERT INTO BorrowingItems (BorrowingID, EquipmentID, Quantity, ReturnedQuantity, CreatedAt, UpdatedAt) VALUES (?, ?, ?, ?, NOW(), NOW())"
            Dim params As New List(Of OleDb.OleDbParameter) From {
                New OleDb.OleDbParameter() With {.Value = newBorrowingID},
                New OleDb.OleDbParameter() With {.Value = item.EquipmentID},
                New OleDb.OleDbParameter() With {.Value = item.Quantity},
                New OleDb.OleDbParameter() With {.Value = item.ReturnedQuantity}
            }
            DataAccess.ExecNonQuery(sql, params)
        Next
    End Sub

    ' Helper classes for seed data
    Private Class EquipmentSeed
        Public Property ItemName As String
        Public Property Category As String
        Public Property Description As String
        Public Property Stock As Integer
        Public Property Unit As String

        Public Sub New(name As String, category As String, desc As String, stock As Integer, unit As String)
            Me.ItemName = name
            Me.Category = category
            Me.Description = desc
            Me.Stock = stock
            Me.Unit = unit
        End Sub
    End Class

    Private Class BorrowerSeed
        Public Property FullName As String
        Public Property ContactNo As String
        Public Property Address As String
        Public Property Email As String

        Public Sub New(name As String, contact As String, address As String, email As String)
            Me.FullName = name
            Me.ContactNo = contact
            Me.Address = address
            Me.Email = email
        End Sub
    End Class

    Private Class BorrowingSeed
        Public Property BorrowerID As Integer
        Public Property BorrowDate As Date
        Public Property ExpectedReturnDate As Date
        Public Property ActualReturnDate As Date?
        Public Property Status As String
        Public Property Notes As String

        Public Sub New(borrowerID As Integer, borrowDate As Date, expectedReturn As Date, actualReturn As Date?, status As String, notes As String)
            Me.BorrowerID = borrowerID
            Me.BorrowDate = borrowDate
            Me.ExpectedReturnDate = expectedReturn
            Me.ActualReturnDate = actualReturn
            Me.Status = status
            Me.Notes = notes
        End Sub
    End Class

    Private Class BorrowingItemSeed
        Public Property BorrowingID As Integer
        Public Property EquipmentID As Integer
        Public Property Quantity As Integer
        Public Property ReturnedQuantity As Integer

        Public Sub New(borrowingID As Integer, equipmentID As Integer, quantity As Integer, returnedQuantity As Integer)
            Me.BorrowingID = borrowingID
            Me.EquipmentID = equipmentID
            Me.Quantity = quantity
            Me.ReturnedQuantity = returnedQuantity
        End Sub
    End Class

End Module

