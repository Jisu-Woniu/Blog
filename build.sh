#!/bin/bash
curl -sSL https://dot.net/v1/dotnet-install.sh >dotnet-install.sh
chmod +x dotnet-install.sh
./dotnet-install.sh -c 6.0 -InstallDir ./dotnet6
./dotnet6/dotnet --version
./dotnet6/dotnet workload install wasm-tools
./dotnet6/dotnet publish -c Release -o output
cat > output/package.json << EOF
{
    "reactSnap": {
        "puppeteer": {
            "timeout": 50000
        },
        "source": "wwwroot",
        "minifyHtml": {
            "collapseWhitespace": true,
            "removeComments": true
        },
        "puppeteerArgs": [
            "--no-sandbox",
            "--disable-setuid-sandbox"
        ]
    }
}
EOF
npm install -g react-snap
cd output
react-snap
cd ..
