const express = require('express');
const router = express.Router();
const multipart = require('connect-multiparty');
const multipart_middleware = multipart();
const controller = require('../controller/StudentController');

router.get('/', function (req, res, next) {
    controller.list(req, res);
});

router.get('/show/:id', function (req, res, next) {
    controller.show(req, res);
});

router.post('/', multipart_middleware, function (req, res) {
    controller.store(req, res, multipart_middleware);
});