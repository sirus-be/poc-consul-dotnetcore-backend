# Consul Backend API sample

## Info

In deze POC wordt een backend service gestart met *envconsul*. 
Deze tool verbindt met consul, en (her)start een process met omgevingsvariabelen.
Alle kv's onder het pad dev/Sirus.Poc.Consul.Backend.RestApi worden als environment meegegeven.

## Commands

Start een consul agent (lokaal)

	.\consul.exe agent -dev -bind='127.0.0.1'

Steek waarden in de key value store

	.\consul.exe kv put dev/Sirus.Poc.Consul.Backend.RestApi/path HiFromConsul

Build & run backend. In root directory van solution:

	docker build -t consulbackend -f .\Sirus.Poc.Consul.Backend.RestApi\Dockerfile .
	docker run -p 3277:80 consulbackend

## See

De waarde uit de omgevingsvariabelel is beschikbaar onder http://localhost:32773/api/values.