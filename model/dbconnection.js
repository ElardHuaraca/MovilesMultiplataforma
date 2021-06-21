var mysql = require('mysql');
var conn = mysql.createConnection({
    host: 'localhost',
    port: '3306',
    user: 'root',
    password: '',
    database: 'lab15multiplaforma'
});

conn.connect(function (err) {
    if (err) {
        console.log("error: " + err);
    }

    let sqlstudent = "CREATE TABLE IF NOT EXISTS STUDENTS(" +
        "StudentID INT PRIMARY KEY," +
        "Name VARCHAR(200) NOT NULL," +
        "Paternal_Surname VARCHAR(200) NOT NULL," +
        "Maternal_Surname VARCHAR(200) NOT NULL," +
        "Birth_Date DATE NOT NULL," +
        "Address VARCHAR(200) NOT NULL)";
    conn.query(sqlstudent, function (err, result) {
        if (err) {
            console.log("error create table: " + err);
        }
    });

    let sqlimage = "CREATE TABLE IF NOT EXISTS IMAGES(" +
        "ImageID INT PRIMARY KEY," +
        "Name VARCHAR(200) NOT NULL," +
        "StudentID INT NOT NULL)";
    conn.query(sqlimage, function (err, result) {
        if (err) {
            console.log("error create table: " + err);
        }
    });
});

module.exports = conn;
