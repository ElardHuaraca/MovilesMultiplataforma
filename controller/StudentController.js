let db = require('../models/dbconection');
const fs = require('fs');

let student = {
    list(req, res) {
        let sql = 'SELECT STUDENTS.StundentID,STUDENTS.Name,Paternal_Surname,Maternal_Surname,Birth_Date,Address, GROUP_CONCAT(imagen.nombre) as imagen' +
            'FROM STUDENTS LEFT JOIN IMAGES ON STUDENTS.StudentID = IMAGES.StudentID GROUP BY STUDENTS.StudentID';
        db.query(sql, function (err, result) {
            if (err) {
                console.log(err);
                res.sendStatus(500);
            } else {
                res.json(result);
            }
        });
    },
    store(req, res) {
        var paths = [];
        if (req.files != undefined) {
            for (let i = 0; i < req.files.uploads.length; i++) {
                var file = req.files.uploads[i];
                var path = file.path;
                var splited = file.path.split('\\');
                var target_path = './public/images/' + splited[splited.length - 1];
                paths[i] = splited[splited.length - 1];
                fs.copyFile(path, target_path, function (err) {
                    if (err) throw err;
                    fs.unlink(path, function () {
                        if (err) throw err;
                    });
                });
            }
        }
        val_id = req.body.StudentID;
        val_name = req.body.Name;
        val_paternal_surname = req.body.Paternal_Surname;
        val_maternal_surname = req.body.Maternal_Surname;
        val_birth_date = req.body.Birth_Date;
        val_address = req.body.Address;
        let sql = 'INSERT INTO STUDENT VALUES(?,?,?,?,?,?)';
        db.query(sql, [val_id, val_name, val_paternal_surname, val_maternal_surname, val_birth_date, val_address], function (err, newStudent) {
            if (err) {
                console.log(err);
                res.sendStatus(500);
            } else {
                if (paths.length > 0) {
                    for (let j = 0; j < paths.length; j++) {
                        let sql_img = 'INSERT INTO IMAGES(Name,StudentID) VALUES(?,?)';
                        db.query(sql_img, [paths[j], newStudent.insertId], function (erro, newImage) {
                            if (erro) {
                                console.log(erro)
                                res, sendStatus(500);
                            }
                            if (j === paths.length - 1) {
                                res.json(newStudent)
                            }
                        })
                    }
                } else {
                    res.json(newStudent)
                }
            }
        });
    },
    show(req, res) {
        val_id = req.params.id;
        let sql = 'SELECT STUDENTS.StundentID,STUDENTS.Name,Paternal_Surname,Maternal_Surname,Birth_Date,Address, GROUP_CONCAT(imagen.nombre) as imagen' +
            'FROM STUDENTS LEFT JOIN IMAGES ON STUDENTS.StudentID = IMAGES.StudentID GROUP BY STUDENTS.StudentID WHERE STUDENTS.StudentID = ?';
        db.query(sql, [val_id], function (err, rowData) {
            if (err) {
                console.log(err);
                res.sendStatus(500);
            } else {
                res.json(rowData);
            }
        });
    }
}