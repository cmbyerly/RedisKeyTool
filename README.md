# Radish - Version 2

## About

This is a simple Redis Key Management GUI for strings, hashes, lists, sets, and sorted sets.  It is build with .Net 5, StackExchange.Redis, and Radzen Blazor Components.

I am adding more stuff to it as I need or people want.

## Debugging

1. Download Visual Studio 2019
2. Set the RadishV2.Server.csproj as your start project.
3. Select IIS Express in your debugging start area.
4. Build solution
5. Start

## Docker

I have been uploading the docker image of this if you just want to use it.

1. `docker run --restart=always --name redis -d -p 6379:6379 redis redis-server --appendonly yes`
2. `docker run --restart=always -d --name radishv2 --link redis:redis -p 9000:80 cmbyerly/radishv2:latest`
3. The access it [Go here](http://localhost:9000)
4. In the "Redis URL and Port" field, put `redis:6379`
5. You can also put in the FQDN instead of `redis:6379` so something like my.qualified.domain:6379

### Hub Page

[Docker Hub](https://hub.docker.com/r/cmbyerly/radishv2)

## Sponsors

The following people are generously sponsoring this project.
