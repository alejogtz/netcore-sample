#!/bin/bash

echo "Starting net-core-api-sample container"

STORAGE_DIR="/app/storage"
if [ ! -d "$STORAGE_DIR" ]; then
	mkdir -p $STORAGE_DIR/media/pdf
	mkdir -p $STORAGE/dotnet/randomfiles
fi

echo "Directories was created succesfully: "
echo [! -d "$STORAGE_DIR"]

