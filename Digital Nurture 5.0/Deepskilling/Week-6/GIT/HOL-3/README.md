# HOL-3 - Git Branching and Merging

## Objective

To understand Git branching and merging.

## Topics Covered

- Creating a Git branch
- Listing local and remote branches
- Switching between branches
- Adding and committing changes
- Comparing branches
- Merging a branch into master
- Viewing Git log
- Deleting a merged branch

## Branching

### 1. Create a New Branch

```bash
git branch GitNewBranch
```

### 2. List All Branches

```bash
git branch -a
```

The `*` symbol indicates the currently active branch.

### 3. Switch to the New Branch

```bash
git checkout GitNewBranch
```

### 4. Add Files and Commit Changes

```bash
git add .
git commit -m "Added files in GitNewBranch"
```

### 5. Check Git Status

```bash
git status
```

## Merging

### 1. Switch to Master

```bash
git checkout master
```

### 2. Check Differences Between Master and Branch

```bash
git diff master GitNewBranch
```

### 3. Merge the Branch into Master

```bash
git merge GitNewBranch
```

### 4. View Git Log

```bash
git log --oneline --graph --decorate
```

### 5. Delete the Merged Branch

```bash
git branch -d GitNewBranch
```

### 6. Check Git Status

```bash
git status
```

## Result

Successfully documented the process of creating a branch, making changes in the branch, merging the branch into master, viewing the Git history, and deleting the merged branch.
