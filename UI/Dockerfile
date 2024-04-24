# Base Image
FROM node:lts-alpine as build-stage

# Set working directory
WORKDIR /app

# Copy necessary dependencies
COPY package*.json ./

# Install dependencies 
RUN npm install

# Copy project files and build
COPY . .
RUN npm run build --prod

# Production Stage
FROM nginx:alpine

# Copy the built Angular app from the build stage
COPY --from=build-stage /app/dist/my-angular-app/browser /usr/share/nginx/html

RUN ls -la /usr/share/nginx/html
