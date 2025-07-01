#!/bin/bash
if [ "$#" -ne 2 ]; then
    echo "Usage: $0 <network> <port>"
    echo "Example: $0 192.168.150 445"
    exit 1
fi

network=$1
port=$2

echo "Scanning network $network.0/24 on TCP port $port ..."

for i in {1..254}; do
    ip="$network.$i"
    (timeout 1 bash -c "echo > /dev/tcp/$ip/$port" 2>/dev/null && echo "[+] $ip is up") &
done

wait
echo "Scan completed."