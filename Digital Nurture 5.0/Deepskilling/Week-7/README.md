# Week-7 - DevOps, Docker and GenAI Fundamentals

## Digital Nurture 5.0 - DotNet FSE Deep Skilling

Week-7 focuses on understanding the fundamentals of:

- DevOps
- Docker
- Generative AI (GenAI)

This README documents the theoretical concepts and learning outcomes covered during Week-7.

---

# 1. DevOps Fundamentals

## What is DevOps?

DevOps is a combination of development practices, tools, and processes that helps development and operations teams work together throughout the software development lifecycle.

The main objective of DevOps is to improve collaboration, automate software delivery processes, and deliver applications faster and more reliably.

## DevOps Lifecycle

A typical DevOps lifecycle consists of:

1. Plan
2. Develop
3. Build
4. Test
5. Release
6. Deploy
7. Operate
8. Monitor

These stages form a continuous software development and delivery process.

## Benefits of DevOps

- Faster software delivery
- Better collaboration between teams
- Continuous integration and delivery
- Increased automation
- Faster identification of issues
- Improved software quality
- Reliable application deployment
- Continuous monitoring and feedback

---

# 2. Continuous Integration and Continuous Delivery

## Continuous Integration - CI

Continuous Integration is a development practice where developers frequently integrate their code changes into a shared source code repository.

Each code change can be automatically built and tested.

Typical CI process:

```text
Developer
    ↓
Code Commit
    ↓
Source Control Repository
    ↓
Build
    ↓
Automated Testing
    ↓
Build Result
```

### Benefits of CI

- Detects integration problems early
- Automates build and testing
- Improves code quality
- Provides faster feedback to developers

## Continuous Delivery / Deployment - CD

Continuous Delivery focuses on automatically preparing validated application changes for deployment.

Continuous Deployment can further automate the process of releasing validated changes into production.

Typical CI/CD workflow:

```text
Code
  ↓
Build
  ↓
Test
  ↓
Package
  ↓
Deploy
  ↓
Monitor
```

---

# 3. Version Control with Git

Git is a distributed version control system used to track changes in source code.

It allows developers to:

- Maintain source code history
- Create branches
- Merge code changes
- Collaborate with other developers
- Connect local repositories with remote repositories

Common Git commands include:

```bash
git init
git status
git add .
git commit -m "Commit message"
git branch
git checkout
git merge
git pull
git push
```

Git concepts and hands-on exercises were practiced during Week-6.

---

# 4. Docker Fundamentals

## What is Docker?

Docker is a containerization platform used to package an application together with its dependencies into a standardized unit called a container.

Containers help applications run consistently across different environments.

## Traditional Deployment

Without containerization:

```text
Application
    ↓
Dependencies
    ↓
Operating System
    ↓
Infrastructure
```

Differences between development, testing, and production environments may cause compatibility problems.

## Containerized Deployment

With Docker:

```text
Application + Dependencies
          ↓
      Docker Image
          ↓
      Docker Container
          ↓
       Docker Engine
          ↓
      Host Operating System
```

The application and its required dependencies can be packaged together.

---

# 5. Docker Image

A Docker image is a read-only template used to create Docker containers.

An image may contain:

- Application code
- Runtime
- Libraries
- Dependencies
- Configuration required by the application

Example:

```text
Dockerfile
    ↓
docker build
    ↓
Docker Image
    ↓
docker run
    ↓
Docker Container
```

---

# 6. Docker Container

A Docker container is a running instance of a Docker image.

Containers are generally:

- Lightweight
- Portable
- Isolated
- Consistent across environments
- Faster to start than traditional virtual machines

Multiple containers can run on the same host system.

---

# 7. Dockerfile

A Dockerfile is a text file containing instructions used to build a Docker image.

Example structure:

```dockerfile
FROM <base-image>

WORKDIR /app

COPY . .

RUN <build-command>

EXPOSE <port>

CMD ["application-command"]
```

Common Dockerfile instructions:

### FROM

Defines the base image.

```dockerfile
FROM <base-image>
```

### WORKDIR

Defines the working directory inside the container.

```dockerfile
WORKDIR /app
```

### COPY

Copies application files into the image.

```dockerfile
COPY . .
```

### RUN

Executes commands while building the image.

```dockerfile
RUN <command>
```

### EXPOSE

Documents the port used by the application.

```dockerfile
EXPOSE 8080
```

### CMD

Defines the default command executed when the container starts.

```dockerfile
CMD ["command"]
```

---

# 8. Basic Docker Commands

Check Docker version:

```bash
docker --version
```

List Docker images:

```bash
docker images
```

List running containers:

```bash
docker ps
```

List all containers:

```bash
docker ps -a
```

Build an image:

```bash
docker build -t application-name .
```

Run a container:

```bash
docker run application-name
```

Stop a container:

```bash
docker stop <container-id>
```

Remove a container:

```bash
docker rm <container-id>
```

Remove an image:

```bash
docker rmi <image-id>
```

---

# 9. Docker Image vs Container

| Docker Image | Docker Container |
|---|---|
| Template used to create containers | Running instance of an image |
| Read-only package | Runtime environment |
| Contains application and dependencies | Executes the packaged application |
| Created using a build process | Created from an image |

Simple relationship:

```text
Dockerfile
    ↓
Docker Image
    ↓
Docker Container
```

---

# 10. Containers vs Virtual Machines

## Virtual Machine

A virtual machine generally includes:

```text
Application
Dependencies
Guest Operating System
Virtualization Layer
Host Operating System
Infrastructure
```

## Container

A container generally uses:

```text
Application
Dependencies
Container Runtime
Host Operating System
Infrastructure
```

Containers typically share the host operating system kernel, making them more lightweight than full virtual machines.

---

# 11. Docker in DevOps

Docker can be used in DevOps pipelines to provide consistent application environments.

Typical workflow:

```text
Developer writes code
        ↓
Code pushed to repository
        ↓
CI pipeline starts
        ↓
Application is built and tested
        ↓
Docker image is created
        ↓
Image is stored in a container registry
        ↓
Application container is deployed
        ↓
Application is monitored
```

This helps maintain consistency across development, testing, and deployment environments.

---

# 12. Introduction to Generative AI

## What is Generative AI?

Generative AI refers to artificial intelligence systems that can generate new content based on patterns learned from data.

Generative AI systems can produce different types of content such as:

- Text
- Code
- Images
- Audio
- Video
- Summaries

---

# 13. Generative AI vs Traditional AI

Traditional AI systems are often designed to perform tasks such as:

- Classification
- Prediction
- Detection
- Recommendation

Generative AI focuses on generating new content.

Example:

```text
User Input / Prompt
        ↓
Generative AI Model
        ↓
Generated Output
```

The generated output may be text, code, images, or other forms of content depending on the model.

---

# 14. Large Language Models - LLMs

Large Language Models are AI models trained on large amounts of textual data.

They can understand and generate natural-language responses based on user input.

LLMs can be used for:

- Question answering
- Text generation
- Summarization
- Translation
- Code generation
- Information extraction
- Conversational applications

---

# 15. Prompt Engineering

Prompt engineering is the process of designing clear instructions or prompts to obtain useful responses from Generative AI systems.

A good prompt generally provides:

- Clear instructions
- Relevant context
- Expected output
- Constraints when necessary

Example:

```text
Role:
Act as a software developer.

Task:
Explain Docker containers.

Requirements:
Explain using simple language and provide an example.

Output:
Provide the answer in bullet points.
```

Clearer prompts generally help the model understand the intended task and desired response format.

---

# 16. Generative AI in Software Development

Generative AI can assist software development activities such as:

- Generating code suggestions
- Explaining existing code
- Creating documentation
- Generating test cases
- Assisting debugging
- Summarizing technical information
- Supporting developer productivity

AI-generated results should still be reviewed and validated before being used in production systems.

---

# 17. Responsible Use of Generative AI

Generative AI should be used responsibly.

Important considerations include:

- Verify AI-generated information
- Review generated code before execution
- Protect confidential and sensitive information
- Consider security and privacy
- Check generated outputs for errors
- Maintain human oversight
- Follow organizational policies

AI-generated content may sometimes contain incorrect or incomplete information, so validation is important.

---

# 18. Relationship Between DevOps, Docker and GenAI

These technologies can support different parts of modern software development.

```text
Software Development
        ↓
Git / Source Control
        ↓
DevOps Practices
        ↓
CI/CD
        ↓
Docker Containerization
        ↓
Application Deployment
        ↓
Monitoring and Improvement
```

Generative AI can assist developers throughout this lifecycle with tasks such as code assistance, documentation, testing support, and technical problem solving.

---

# Week-7 Learning Summary

During Week-7, the following theoretical concepts were studied:

## DevOps

- Introduction to DevOps
- DevOps lifecycle
- Benefits of DevOps
- Continuous Integration
- Continuous Delivery and Deployment
- Git in DevOps workflows

## Docker

- Introduction to containerization
- Docker images
- Docker containers
- Dockerfile basics
- Basic Docker commands
- Images vs containers
- Containers vs virtual machines
- Docker usage in DevOps workflows

## Generative AI Fundamentals

- Introduction to Generative AI
- Generative AI vs traditional AI
- Large Language Models
- Prompt engineering
- Generative AI use cases
- Generative AI in software development
- Responsible use of Generative AI

---

# Conclusion

Week-7 provided a theoretical understanding of DevOps, Docker, and Generative AI fundamentals.

DevOps introduces practices for collaboration, automation, continuous integration, delivery, and deployment.

Docker provides containerization capabilities that help package applications and their dependencies into consistent and portable environments.

Generative AI provides capabilities for generating and assisting with content such as text and code and can support different stages of software development when used responsibly.

These concepts provide foundational knowledge for modern software development, deployment, automation, and AI-assisted development.
