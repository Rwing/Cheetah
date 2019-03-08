# A static file server in .Net Core 2.2

## Features

* [x] Docker support
* [x] Upload file


## Todo

* [ ] List files

## How to use
BUILD:
```
docker build -t Cheetah .
```

RUN:
```
docker run -d -v /your/storage:/app/wwwroot -p 8082:80 Cheetah:latest
```
