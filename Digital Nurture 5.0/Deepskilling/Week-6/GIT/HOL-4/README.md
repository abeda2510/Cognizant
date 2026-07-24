# HOL-4 - Git Merge Conflict Resolution

## Objective

To understand how merge conflicts occur in Git and how to resolve them successfully.

## Topics Covered

- Creating and switching Git branches
- Creating files in different branches
- Committing changes
- Merging branches
- Identifying merge conflicts
- Resolving merge conflicts
- Committing resolved changes
- Verifying Git repository status

## Steps Performed

### 1. Created GitWork Branch

Created a new branch named `GitWork`.

```bash
git branch GitWork
git branch
git checkout GitWork
```

### 2. Created hello.xml in GitWork Branch

Created `hello.xml` with content specific to the `GitWork` branch.

```bash
echo "<message>Hello from GitWork Branch</message>" > hello.xml
```

Verified the file:

```bash
cat hello.xml
git status
```

### 3. Committed Changes in GitWork

Added and committed `hello.xml`.

```bash
git add hello.xml
git commit -m "Add hello.xml in GitWork branch"
git status
```

### 4. Switched to Master Branch

```bash
git checkout master
```

Created another `hello.xml` with different content:

```bash
echo "<message>Hello from Master Branch</message>" > hello.xml
```

Committed the changes:

```bash
git add hello.xml
git commit -m "Add hello.xml in master"
```

### 5. Merged GitWork into Master

Attempted to merge the `GitWork` branch:

```bash
git merge GitWork
```

This resulted in a merge conflict in:

```text
hello.xml
```

Git displayed:

```text
CONFLICT (add/add): Merge conflict in hello.xml
Automatic merge failed; fix conflicts and then commit the result.
```

### 6. Resolved the Merge Conflict

Updated `hello.xml` with the resolved content:

```bash
echo "<message>Merge conflict resolved successfully</message>" > hello.xml
```

Added the resolved file:

```bash
git add hello.xml
```

Committed the merge conflict resolution:

```bash
git commit -m "Resolve merge conflict"
```

### 7. Verified Final Git Status

```bash
git status
```

Final result:

```text
On branch master
nothing to commit, working tree clean
```

## Output Screenshots

The `Outputs` folder contains screenshots demonstrating the hands-on execution:

1. `01-GitWork-Branch-Created.png`
2. `02-GitWork-HelloXML-Status.png`
3. `03-GitWork-HelloXML-Commit.png`
4. `04-Merge-Conflict.png`
5. `05-Conflict-Resolved.png`

## Result

Successfully created a Git branch, made different changes in the branch and master, generated a merge conflict in `hello.xml`, resolved the conflict, committed the resolved changes, and verified that the working tree was clean.

## Conclusion

This hands-on demonstrated how Git handles conflicting changes between branches and how merge conflicts can be manually resolved and committed successfully.
