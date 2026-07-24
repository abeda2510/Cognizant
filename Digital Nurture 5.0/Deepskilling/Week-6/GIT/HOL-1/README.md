# HOL 1 - Git Setup and Basic Commands

## Objective

To understand and practice basic Git commands and Git configuration.

## Topics Covered

- Git installation verification
- Git user configuration
- Git repository initialization
- Creating and tracking files
- Git status
- Git add
- Git commit
- Git pull
- Git push
- Working with a remote repository

## Git Commands

### Check Git Version

git --version

### Configure Git Username

git config --global user.name "Your Name"

### Configure Git Email

git config --global user.email "your-email@example.com"

### Check Git Configuration

git config --list

### Create GitDemo Directory

mkdir GitDemo

cd GitDemo

### Initialize Git Repository

git init

### Check Repository Files

ls -la

### Create welcome.txt

echo "Welcome to Git Hands-On Lab" > welcome.txt

### Check File

ls

### View File Content

cat welcome.txt

### Check Git Status

git status

### Add File to Staging Area

git add welcome.txt

### Commit Changes

git commit -m "Add welcome.txt"

### Pull From Remote Repository

git pull origin master

### Push to Remote Repository

git push origin master

## File Created

welcome.txt

## Result

Successfully practiced basic Git operations including repository initialization, file creation, staging, committing, pulling, and pushing changes to a remote repository.
