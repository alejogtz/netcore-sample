# Net Core Sample

Includes a simple crud operations to manage files, and a single database entity.

### Pre-requisite

- [] Docker installed

## Installation With Docker

Clone the repository and get into repo folder

```bash
git clone https://github.com/alejogtz/netcore-sample.git
cd netcore-sample.git/
```

Move into Docker folder and buid the Docker image

```bash
cd Docker/
docker build --tag docker.io/netcore-sample:1.0 --rm --no-cache .
```

Once the build image have finished, run a container

```
docker run --name demo
```

## Installation with docker-compose
`...pending`


## Usage

You can test the container is running by run the command
```bash
curl https://localhost:8181/archivos
```

## License
[MIT](https://choosealicense.com/licenses/mit/)