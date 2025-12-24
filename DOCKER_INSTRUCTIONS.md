# Docker Build and Run Instructions

This file contains instructions on how to build and run the `NuGetTool.Web` application using Docker.

## Prerequisites

- Docker installed on your machine.
- The repository content (including `NuGetTool.Web`, `NuGetTool.Core`, and the `Dockerfile`).

## Build the Image

Open a terminal at the solution root and run the following command to build the Docker image:

```bash
docker build -t nugettool-web .
```

## Run the Container

Once the image is built, you can run it as a container:

```bash
docker run -d -p 8080:8080 --name nugettool nugettool-web
```

## Access the Application

Open your browser and navigate to:

[http://localhost:8080](http://localhost:8080)

## Troubleshooting

- **Port Conflicts**: If port 8080 is already in use, you can map to a different host port:
  ```bash
  docker run -d -p 9000:8080 --name nugettool nugettool-web
  ```
  Then access it at `http://localhost:9000`.
- **Base Image**: This Dockerfile uses `.NET 9.0`. Ensure your environment supports this or adjust the `mcr.microsoft.com/dotnet` tags in the `Dockerfile` if necessary.
