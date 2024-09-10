# What is this?

A small sample project to easily replicate issues with Traefik and NTLM authentication.

This project requires a Windows Docker host (ex. via Docker Desktop), as it is based
around a Windows image.

**Note: this project has been developed on a Windows 10 machine and
it might NOT work on a Windows 11 machine, as Windows images are very picky when it comes
to Docker hosts.***

## A note on certificates
This sample app uses no publicly trusted certificates for HTTPS. The base image generates a
self-signed certificate while Traefik, described in the
[Running with Traefik](#running-with-traefik) section, uses a staging certificate resolver which
will never yield a certificate in the current setup which forces Traefik to use an internal,
self-signed certificate instead.

# Running app by itself

The small ASP .NET Core applicaiton will respond with the current UTC date-time and the current username after navigating to `http://localhost/data` or `https://localhost/data`, if ran by itself.

**The available username for testing is `test`. There is no password (blank).**

To run this build the Docker image using
```
docker build -t <mytag> .
```
then start the image using
```
docker run -p 80:80 -p 443:443 <mytag>
```

# Running with Traefik

To run this all thay should be required is to run:
```
docker compose up -d
```
from the project folder.

## Assumptions

The file `./services/backend.yml` contains the Traefik definition for the backend test service.
Note that the `Host` is using `test.local`, and this is expected to be a valid `HOSTS` file or
DNS entry. Obviously this can be changed for testing of various scenarios.
