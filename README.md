[![Docker Pulls](https://img.shields.io/docker/pulls/rwingcn/cheetah.svg?maxAge=604800)](https://hub.docker.com/r/rwingcn/cheetah)

# A static file server in .Net Core 2.2

## Features

* [x] Docker support
* [x] Upload file
* [x] Image resize

## Todo

* [ ] List files

## How to use
RUN:
```
docker run -d -v /your/storage:/app/wwwroot -p 8080:80 rwingcn/cheetah:latest
```
UPLOAD:
```
curl -X POST \
  http://localhost:8080/api/upload \
  -H 'content-Type: multipart/form-data; boundary=----WebKitFormBoundary7MA4YWxkTrZu0gW' \
  -F 'file=@C:\test.jpg' \
  -F width=200 \
  -F height=100
```