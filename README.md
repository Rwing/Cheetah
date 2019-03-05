BUILD:
```
docker build -t Cheetah .
```

RUN:
```
docker run -d -v /your/storage:/app/wwwroot -p 8082:80 Cheetah:latest
```