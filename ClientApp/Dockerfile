FROM node:15.12.0-alpine3.10 as build
WORKDIR /app
EXPOSE 80
COPY src ./src
COPY *.json ./
RUN npm install -g @angular/cli@7.3.10
RUN npm install
RUN ng build --prod

FROM nginx:1.17.6-alpine as deploy
WORKDIR /app
COPY --from=build /app/dist/ClientApp/ /usr/share/nginx/html/
COPY ./src/nginx.conf /etc/nginx/nginx.conf