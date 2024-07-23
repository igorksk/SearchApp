# Frontend Dockerfile
FROM node:18-alpine

WORKDIR /app

COPY ./search-app/package*.json ./

RUN npm install

COPY ./search-app .

EXPOSE 3000

CMD ["npm", "start"]