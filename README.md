# Administration-for-Software-Developers
Assignment 1 for ARP400

Assignment instructions:
      You are required to develop software that supports the administration of a software company which employs programmers each of whom has an expertise in a  particular programming language, e.g. C#, C++ or Java.
      All programmers are paid a basic monthly salary of around 30000 kr per month. However, it may vary from programmer to programmer.

       As they are in demand a 10% enhancement of the basic salary is paid to each programmer that specializes in C#. However, programmers may

      change their specialist language and their salary enhancement should change accordingly. For example, after suitable training,

      a Java programmer could become a C# programmer.

      When a new programmer joins the staff a more experienced programmer is assigned to him as a mentor. Both must specialize in the same programming language.

      The basic idea behind this practice is that the new recruit (the mentee) will beneﬁt from the experience of the mentor. As this is extra work for the mentor,

      he is awarded 5% of current salary enhancement for every mentee under his supervision.

      When a programmer no longer needs a mentor the mentor’s salary is changed accordingly.    

      For administrative purposes each employee has a name and a unique payroll number.


      The programme should show a detailed report for each programmer      

          His payroll nummber and name
          The specialist programming language and current monthly salary together with details of any programmers that he is mentoring or is mentored by

      The report should show also a total monthly salary bill for the company 


-----------------------------------------------------------------------------------------------------------------------------------------------------------------

This application works in a way that you create employees who you then can keep as ordinary programmers, or convert to either mentors or mentees. To create persistance between executions of the applications the records of the different types of employees are saved in XML files that the application reads from on execution.

Polymorphism has been used on all the different classes since the XML serializer needs parameterless constructors and the creation of objects needs a different constructor.

I chosed to use Generic Lists as my choice for a collection as they seemed to be the best choice for storing objects as i've done. However in retrospect i think that i could have benefited more from using Dictionaries as i could have used their unique key value to keep things more organized.
