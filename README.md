# TeamTool

This application may be used by Signifly to assemble project teams for its clients.

The application provides an interface to compose a team and view a team as well as projects and members.

## Technologies

1. Backend: ASP.NET Core MVC 
2. Database: Entity Framework Core (Sql Database)
3. Frontend: Razor, Bootstrap and jQuery

## Data Model
1. Team
2. Member
3. Project
4. TeamMember 
  1. Joined association table used to separate many-to-many relationship between Team and Member entities)

## Functional Requirements
1. As a consultant, I want to assemble a team and generate a link containing information about the team to a client 
	1. I should be able to compose a team in the UI and receive a link upon creation 
	2. Link should contain pictures of team members, contact details and background information
2. As a client, I want to compose a team and send a request to Signifly
  1. The request should contain a description of the project 
3. As a client or consultant, I want to view a team based on a link 
  1. The link should show team member pictures, contact details and background information 
  
## Non-Functional Requirements

1. Usability and design: tool should be consistent with Signifly’s quality standards and visual identity

## Missing

* Open Bug: Members not added to team upon creation 
* Signifly Styling
* Feature: Team page does not display pictures of members (only names)

## Assumptions

* Authentication has not been addressed
* Details about projects such as its creation date and deadline has not been included (might be relevant to client)
* Team members are currently hard coded on the server
