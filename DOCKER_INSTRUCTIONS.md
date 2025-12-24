# Docker Build and Run Instructions

This file contains instructions on how to build and run the `NuGetTool.Web` application using Docker.

## Prerequisites

- Docker installed on your machine.
- The repository content (including `NuGetTool.Web`, `NuGetTool.Core`, and the `Dockerfile`).

## Option 1: Pull from Registry (Recommended)

If you are on another PC, you don't need the source code. Just pull the latest image from the GitHub Container Registry:

```bash
docker pull ghcr.io/displayname2023/nugettool/nugettool-web:latest
```

## Option 2: Build Locally

If you have the source code, open a terminal at the solution root and run:

```bash
docker build -t nugettool-web .
```

## Run the Container

Once you have the image (either by pulling or building), run it:

```bash
docker run -d -p 8080:8080 --name nugettool ghcr.io/displayname2023/nugettool/nugettool-web:latest
```

*(Note: If you built it locally and tagged it as `nugettool-web`, use that name instead of the ghcr.io path in the run command.)*

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
