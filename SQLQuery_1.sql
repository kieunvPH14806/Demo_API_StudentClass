USE DemoStudentDPOTECH
go

-- Insert rows into table 'Class' in schema '[dbo]'
INSERT INTO [dbo].[Class]
( -- Columns to insert data into
 [IdClass], [NameClass], [Classroom], [State]
)
VALUES
( -- First row: values for the columns in the list above
 1, 'IT16313', 'P305',1
),
( -- Second row: values for the columns in the list above
 2, 'IT16312', 'L207',1
),
( -- Second row: values for the columns in the list above
 3, 'IT16314', 'L203',1
),
( -- Second row: values for the columns in the list above
 4, 'IT16301', 'L205',1
)
-- Add more rows here
GO
-- Insert rows into table 'Student' in schema '[dbo]'
INSERT INTO [dbo].[Student]
( -- Columns to insert data into
 [IdStudent], [Name], [birth],[State]
)
VALUES
( -- First row: values for the columns in the list above
 1, N'Nguyễn Văn Kiều', '1998-8-9',1
),
( -- Second row: values for the columns in the list above
 2, N'Phí Thị Trang', '2002-06-27',1
),
( -- Second row: values for the columns in the list above
 3, N'Lê Văn Lưu', '2002-06-27',1
),
( -- Second row: values for the columns in the list above
 4, N'Nguyễn Khắc Kiên', '2002-06-27',1
)
-- Add more rows here
GO

-- Insert rows into table 'StudentClass' in schema '[dbo]'
INSERT INTO [dbo].[StudentClass]
( -- Columns to insert data into
[IdStudent],[IdClass],[State]
)
VALUES
( 
 1, 1, 1
),
( 
 1, 2,1
),
(
 1, 3,1
),
( 
 2, 2,1
),
( 
 3, 2,1
),
( 
 4, 2,1
),
( 
 3, 4,1
),
( 
 4, 4,1
),
( 
 4, 1,1
)

-- Add more rows here
GO

-- Select rows from a Table or View '[Student] join [dbo].[StudentClass] on [Student].' in schema '[dbo]'
SELECT * FROM Student JOIN [StudentClass] on Student.IdStudent=[StudentClass].[IdStudent]
                      JOIN Class ON Class.IdClass=[StudentClass].[IdClass]
                      WHERE Class.NameClass like N'IT16312'

-- Delete rows from table '[StudentClass]' in schema '[dbo]'
DELETE FROM [dbo].[StudentClass]

GO