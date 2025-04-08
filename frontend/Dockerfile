# Frontend Dockerfile
FROM node:alpine

WORKDIR /app

EXPOSE 3000

COPY ./search-app/package*.json ./
RUN npm install

COPY ./search-app .

CMD ["npm", "start"]