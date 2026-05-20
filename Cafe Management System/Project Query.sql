CREATE DATABASE cafedb;
use cafedb;

CREATE TABLE Users (
    user_id INT PRIMARY KEY IDENTITY(1,1),
    username NVARCHAR(50) NOT NULL UNIQUE,
    password NVARCHAR(50) NOT NULL,
    role NVARCHAR(10) NOT NULL CHECK (role IN ('User', 'Admin')),
    created_at DATETIME DEFAULT GETDATE()
);

CREATE TABLE Items (
    item_id INT PRIMARY KEY IDENTITY(1,1),
    item_name NVARCHAR(100) NOT NULL,
    item_price DECIMAL(10, 2) NOT NULL,
    item_category NVARCHAR(50) NOT NULL,
    created_at DATETIME DEFAULT GETDATE()
);

CREATE TABLE Orders (
    order_id INT PRIMARY KEY IDENTITY(1,1),
    user_id INT FOREIGN KEY REFERENCES Users(user_id),
    order_date DATETIME DEFAULT GETDATE(),
    total_price DECIMAL(10, 2) NOT NULL,
    payment_method NVARCHAR(20) NOT NULL
);

CREATE TABLE OrderDetails (
    order_detail_id INT PRIMARY KEY IDENTITY(1,1),
    order_id INT FOREIGN KEY REFERENCES Orders(order_id),
    item_id INT FOREIGN KEY REFERENCES Items(item_id),
    quantity INT NOT NULL,
    price DECIMAL(10, 2) NOT NULL
);

-- Insert some example items into the Items table
INSERT INTO Items (item_name, item_price, item_category)
VALUES 
    ('Cheese Burger', 5.99, 'Burgers'),
    ('Veggie Burger', 4.49, 'Burgers'),
    ('Grilled Chicken Sandwich', 6.99, 'Sandwiches'),
    ('Caesar Salad', 3.99, 'Salads'),
    ('French Fries', 2.49, 'Sides'),
    ('Chocolate Milkshake', 3.59, 'Drinks'),
    ('Lemonade', 2.79, 'Drinks'),
    ('Spaghetti Bolognese', 8.99, 'Pasta'),
    ('Margherita Pizza', 7.99, 'Pizza'),
    ('Pepperoni Pizza', 8.49, 'Pizza');

select * from OrderDetails

INSERT INTO Users (username, password, role)
VALUES ('admin', 'admin123', 'Admin');

ALTER TABLE Orders
DROP CONSTRAINT FK__Orders__user_id__2C3393D0;

ALTER TABLE Orders
ALTER COLUMN user_id INT NULL;

-- Step 3: Add the foreign key constraint with ON DELETE SET NULL
ALTER TABLE Orders
ADD CONSTRAINT FK_Orders_user_id
FOREIGN KEY (user_id) REFERENCES Users(user_id)
ON DELETE SET NULL;


