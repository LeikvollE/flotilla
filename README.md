# Flotilla

Flotilla is the main point of access for operators to interact with multiple robots in a facility. The application
consists of a [frontend](frontend/README.md) in React, a [backend](backend/README.md) in Python using the FastAPI
framework and a Mosquitto MQTT Broker.

## Setup

For development, please fork the repository. Then, clone the repository:

```
git clone https://github.com/equinor/flotilla
```

## Run with docker

Install docker using the [official documentation](https://docs.docker.com/engine/install/ubuntu/).

Install docker compose:

```
sudo apt update
sudo apt install docker-compose
```

Build the docker container:

```
docker-compose build
```

Start Flotilla by running:

```
docker-compose up
```

or

```
docker-compose up --build
```
