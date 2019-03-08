[![Docker Pulls](https://img.shields.io/docker/pulls/rwingcn/cheetah.svg?maxAge=604800)](https://hub.docker.com/r/rwingcn/cheetah)

# A static file server in .Net Core 2.2

## Features

* [x] Docker support
* [x] Upload file


## Todo

* [ ] List files

## How to use
RUN:
```
docker run -d -v /your/storage:/app/wwwroot -p 8080:80 rwingcn/cheetah:latest
```
UPLOAD:
```
POST /api/upload HTTP/1.1
Host: localhost:8080
Content-Type: multipart/form-data; boundary=----WebKitFormBoundary7MA4YWxkTrZu0gW
Content-Disposition: form-data; name="file"; filename="C:\test.jpg
------WebKitFormBoundary7MA4YWxkTrZu0gW--
```