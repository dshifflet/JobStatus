# Job Status Viewer
```
     ____.     ___. ____   ____.__                            
    |    | ____\_ |_\   \ /   /|__| ______  _  __ ___________ 
    |    |/  _ \| __ \   Y   / |  |/ __ \ \/ \/ // __ \_  __ \
/\__|    (  <_> ) \_\ \     /  |  \  ___/\     /\  ___/|  | \/
\________|\____/|___  /\___/   |__|\___  >\/\_/  \___  >__|   
                    \/                 \/            \/       
```

## OVERVIEW:
Example of how to display multi-threaded job status with windows forms.

Looks like...
![alt text](https://raw.githubusercontent.com/dshifflet/JobStatus/master/imgs/capture1.PNG "Example Screen Shot")

Each job supports the following events...
```
        public delegate void JobCompletedHandler(string name, string msg); //Starts it ADDS IT TO THE GRID VIEW
        public delegate void JobFailedHandler(string name, string msg); //Flags as Failed (RED)
        public delegate void JobStartedHandler(string name, string msg); //Flags as Completed (GREEN)
        public delegate void JobProgressHandler(string name, string msg, int percent); //Moves the progress box
        public delegate void JobOverallStatusHandler(string msg); //Updates the Task Bar
        public delegate void JobOverallCompletedHandler(string msg); //Displays a message Box
```
Project includes a simple sample so you can see how to wire things up.
