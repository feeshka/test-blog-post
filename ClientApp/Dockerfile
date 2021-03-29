FROM node:15.12.0-alpine3.10 as build
WORKDIR /app
EXPOSE 4200
COPY src ./src
COPY *.json ./
RUN npm install -g @angular/cli@7.3.10
RUN npm install
RUN ng build --prod

FROM nginx:alpine as deploy
WORKDIR /app
COPY --from=build /app/dist/ClientApp/*.* /usr/share/nginx/html/