FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.sln .
COPY Cheetah.Web/*.csproj ./Cheetah.Web/
RUN dotnet restore -r linux-x64

# copy everything else and build app
COPY . ./
WORKDIR /app/Cheetah.Web
RUN dotnet publish -c Release -r linux-x64 -o out


FROM microsoft/dotnet:2.2-aspnetcore-runtime AS runtime
ENV TZ=Asia/Shanghai
ARG DEPLOY_ENV=Development
ENV ASPNETCORE_ENVIRONMENT ${DEPLOY_ENV}
WORKDIR /app
COPY --from=build /app/Cheetah.Web/out ./
ENTRYPOINT ["dotnet", "Cheetah.Web.dll"]