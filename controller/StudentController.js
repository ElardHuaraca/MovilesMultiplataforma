let db = require('../model/dbconnection');
const fs = require('fs');

let student = {
    list(req, res) {
        let sql = 'SELECT students.StudentID, students.Name, students.Paternal_Surname, ' +
            'students.Maternal_Surname, students.Birth_Date, students.Address, ' +
            'GROUP_CONCAT(images.Name) AS Image FROM students ' +
            'LEFT JOIN images ON images.StudentID = students.StudentID GROUP BY students.StudentID'
        db.query(sql, function (err, result) {
            if (err) {
                console.log("hay un errror")
                console.log(err);
                res.sendStatus(500);
            } else {
                res.json(result);
            }
        });
    },
    store(req, res) {
        var paths = [];
        if (req.files.uploads != undefined) {
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
        let sql = 'INSERT INTO students VALUES(?,?,?,?,?,?)';
        db.query(sql, [val_id, val_name, val_paternal_surname, val_maternal_surname, val_birth_date, val_address], function (err, newStudent) {
            if (err) {
                console.log(err);
                res.sendStatus(500);
            } else {
                if (paths.length > 0) {
                    for (let j = 0; j < paths.length; j++) {
                        let sql_img = 'INSERT INTO images(Name,StudentID) VALUES(?,?)';
                        db.query(sql_img, [paths[j], val_id], function (erro, newImage) {
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
        let sql = 'SELECT students.StudentID, students.Name, students.Paternal_Surname, ' +
            'students.Maternal_Surname, students.Birth_Date, students.Address, ' +
            'GROUP_CONCAT(images.Name) AS Image FROM students ' +
            'LEFT JOIN images ON images.StudentID = students.StudentID WHERE students.StudentID = ? ' +
            'GROUP BY students.StudentID';
        db.query(sql, [val_id], function (err, rowData) {
            if (err) {
                console.log(err);
                res.sendStatus(500);
            } else {
                res.json(rowData);
            }
        });
    },
    edit(req, res) {
        val_id = req.body.StudentID;
        val_name = req.body.Name;
        val_paternal_surname = req.body.Paternal_Surname;
        val_maternal_surname = req.body.Maternal_Surname;
        val_birth_date = req.body.Birth_Date;
        val_address = req.body.Address;
        let sql = 'UPDATE students SET Name = ?, Paternal_Surname = ?, Maternal_Surname = ?, ' +
            'Birth_Date = ?, Address = ? WHERE StudentID = ?';
        db.query(sql, [val_name, val_paternal_surname, val_maternal_surname,
            val_birth_date, val_address, val_id], function (err, updateData) {
                if (err) {
                    console.log(err);
                    res.sendStatus(500);
                } else {
                    if (req.body.dell != '' && req.body.dell != undefined) {
                        for (let i = 0; i < req.body.dell.length; i++) {
                            var img = req.body.dell[i];
                            var path = './public/images/' + img;
                            fs.unlink(path, function (err) {
                                if (err) throw err;
                            });
                            let sql = 'DELETE FROM images WHERE Name = ? AND StudentID = ?';
                            db.query(sql, [img, val_id], function (err, updateData) {
                                if (err) {
                                    console.log(err);
                                    res.sendStatus(500);
                                }
                            });
                        }
                    }
                    if (req.files.uploads != undefined) {
                        var paths = [];
                        for (let k = 0; k < req.files.uploads.length; k++) {
                            var file = req.files.uploads[k];
                            var path = file.path;
                            var splited = file.path.split('\\');
                            var target_path = './public/images/' + splited[splited.length - 1];
                            paths[k] = splited[splited.length - 1];
                            fs.copyFile(path, target_path, function (err) {
                                if (err) throw err;
                                fs.unlink(path, function () {
                                    if (err) throw err;
                                });
                            });
                        }
                        for (let j = 0; j < paths.length; j++) {
                            let sql = 'INSERT INTO images(Name, StudentID) VALUES (?,?)';
                            db.query(sql, [paths[j], val_id], function (err, newImage) {
                                if (err) {
                                    console.log(err);
                                    res.sendStatus(500);
                                }
                                if (j === paths.length - 1) {
                                    res.json(newImage);
                                }
                            });
                        }
                    } else {
                        res.json(updateData);
                    }
                }
            });
    },
    delete(req, res) {
        val_id = req.params.id;
        let sql = 'SELECT * FROM images WHERE StudentID = ?';
        db.query(sql, [val_id], function (err, result) {
            if (err) {
                console.log(err);
                res.sendStatus(500);
            } else {
                for (let i = 0; i < result.length; i++) {
                    var path = './public/images/' + result[i].Name;
                    fs.unlink(path, function (err) {
                        if (err) { throw err; }
                    });
                }
            }
        });
        let sql2 = 'DELETE FROM students WHERE StudentID = ?';
        let sql3 = 'DELETE FROM images WHERE StudentID = ?';
        db.query(sql2, [val_id], function (err, newData) {
            if (err) {
                console.log(err);
                res.sendStatus(500);
            } else {
                db.query(sql3, [val_id], function (err, data) {
                    if (err) {
                        console.log(err);
                        res.sendStatus(500);
                    } else {
                        res.sendStatus(200);
                    }
                });
            }
        });
    }
}

module.exports = student;