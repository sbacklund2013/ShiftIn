# Shiftin
###### *__A site for all car enthusiasts__*
##### Table of Contents
* About the Project
* Requirements 	
* Design	
* New Technologies
* Design Approach
* Risks and Challenges
* Current Issues
##
### About the Project
For as long as "car guys" has been on the internet there have been car websites. Today you do not even have to buy a repair manual because someone somewhere has dealt with the same issue and wrote a post about it on some website. This has created thriving online communities of enthusiasts, but they are all on different sites. If you own a Honda Civic then you are on some civic forum, if you own a Ford Mustang, then you on the Mustang forums. Having got into cars myself in the last couple of years I found it so strange there was not a platform for all car people, together. I have seen various apps pop up here and there that try to catch the market, but it is never executed correctly. The apps focus on monetization and being as close to Instagram as possible while still maintaining a car-like theme. All these apps and websites were missing some core features that enthusiasts seem to like a Garage profile (where you can list your cars etc), a categorized forum (where you can post questions and find answers), and a meet maker (where users can schedule live events and meet up). Overall, Shiftin seeks to bring together all these amazing car forums into one community site where users can ask questions, create events, show off their cars, and meet new people.

##
### Requirements
Functional Features | Description
------------ | -------------
Account | Shiftin should support users creating, editing, and deleting their accounts.
Profile | Shiftin should support users creating, updating, and deleting profiles. A profile should include modern social media-like features including profile pictures, some interests, and some text. 
Forum | The forums will be categorized threads of text and images to promote thorough communication. Anyone can read the forum, but only registered accounts can reply. 
Events | Shiftin must support the creation of events. Users should also be able to mark that they intend to come. 

Other requirements | Description
------------ | -------------
Security | Shiftin should secure all personal data from users as well as maintain strong application security to protect the users. 
Performance | Shiftin must maintain performance through higher user counts and data storage.
Upgradability | The application must be able to support regular updates without significant downtime. 
Open source | Shiftin must remain open source to encourage community involvement and lower maintenance costs. 
##
### Design
The project is designed around object-oriented principles, model-view-controller design pattern, and N-Layer architecture. Object-oriented approach is taken to ensure code reusability and updateability. MVC pattern was used for ease of security, code updatability, organization, and reusability. The N-layer architecture was utilized to ensure independent functioning components that can be updated or switched without having to edit every file. N-Layer also helps with code organization preventing "spaghetti code". These design aspects support business requirements for low-cost development, bug fixes, and deployment.

###### Current Project UML
<img src="https://github.com/sbacklund2013/ShiftInDocs/blob/main/uml.jpg?raw=true" alt="" data-canonical-src="https://gyazo.com/eb5c5741b6a9a16c692170a41a49c858.png" width="500" height="auto" />

###### Site Map
![Current Site Map](https://github.com/sbacklund2013/ShiftInDocs/blob/main/sitemap.png?raw=true)

###### Site Flow Chart
![Current Flow Chart](https://github.com/sbacklund2013/ShiftInDocs/blob/main/siteflow.png?raw=true)

###### Componenet Model
![Current Components Model](https://github.com/sbacklund2013/ShiftInDocs/blob/main/componentmodel.png?raw=true)

###### Database Entity Model
![Current ER Diagram](https://github.com/sbacklund2013/ShiftInDocs/blob/main/ER%20Diagram.PNG?raw=true)

##### Technologies

Technologies | Justification
------------ | -------------
.Net 5 | Open Source, Cross-platform runtimes, and rapid development. The most current Microsoft framework.
C# | Widely used and supported language.
Identity Framework | Out-of-the-box encryption, two-factor support, and protected session management.
Entity Framework | Rapid development time, Asynchronous database calls, speed.  
Bootstrap | Widely used, Creates responsive pages, is small in size.
###### Architecture Diagram
![Current Architecture Diagram](https://github.com/sbacklund2013/ShiftInDocs/blob/main/architecturediagram.png?raw=true)
##
### Development Approach
#### *Feature Driven*

The feature-driven approach was taken to ensure consistent updates and easy management for a small team. Feature-driven development allows us to keep a user-centric approach when building Shiftin. The process begins with our user stories. User stories are requests from users or ideas from developers for improvements to the website. From user stories, a new feature is added to the feature list. The feature is then claimed by a developer for the creation and a branch is created. From there, the feature enters the CI/CD workflow. 

__Current Feature List__

*Initial Modules*
- [x] Account creation, modification, and deletion
- [x] Profile creation, modification, and deletion
- [x] Car creation, modification, and deletion
- [x] Event creation, modification, and deletion
- [x] Forum post creation and deletion

*Feature List*

- [x] Forum post replies
	- [ ] Forum reply edit 	
- [x] Forum search box
- [x] Forum post upvote/like
- [x] Add cars to my profile
	- [x] Add images to my cars
	- [x] Add descriptions of car mods
	- [x] Change car images
	- [ ] Image preview of car images
- [x] Mark to attend an event
	- [x] Show attendee count on the event page
	- [ ] Revoke attendence 
- [ ] Following/er module
	- [ ] See what events followed is attending
	- [ ] See forum posts and replies
	- [ ] Addition of follow button on profile page
	- [ ] Backend follower/ing support
		- [ ] Database table, C# model, FollowerService
		
##
### Risks and Challenges

*Scale*

Building the application for scale was by far the biggest challenge. The app must be built to be upgradable, reliable, and fast at the same time. This meant sticking to the architecture plan, single responsibility, and other best practices. I also used asynchronous calls where ever possible, this helps lower page rendering times.


*Reliability*

 Creating a reliable app is another challenge and an open-source project can sometimes get carried away. I decided to utilize tried and true methods, dependencies, and frameworks where I could. I utilized .Net Core 5 because it is the most up-to-date and is actively being maintained. I also utilized the Identity Framework library for my authentication system because it is far faster, more secure, and reliable than anything I would spend weeks creating. Overall, reliability is addressed through proper best practice dependency management as well as utilizing tried and true open source options. 
 
*Learning Curve* 

A lot of this technology was new to me. I had not utilized Entity Framework before working on this application. It was a risk to learn so many new things and try to create a usable product at the same time. In the end, I utilized lots and lots of documentation as well as sample projects and examples. 

##
### Current Issues
	
*Image Processing and Storage*

The current system in place for storing user images is not scalable. With hosting being done in the cloud it would increase the bill exponentially by storing images on the server. A proposed solution is Azure Storage which allows us to create blobs for profile image data.
