# CV
1. Create github repo.
2. Create microsoft azure subscription (student). Review microsoft azure infrastructure and get engaged with capabilities of this cloud platfor. Watch some videos 
on youtube.
- Review App Services.
- Check if SQL db is available for free -- if not lets discuss.
- Read about dependency injection and repository patterns.
3. In VS 2022 create ASP.NET Core web application
- Use empty ASP.NET Core (.NET 6) project template.
- Add bootstrap css/js library (from CDN https://www.bootstrapcdn.com/). Get familiar with this library (watch some video on youtube). Grid component.
- Add ASP.NET MVC layout for future website. Use bootstrap. Header (top menu: About me, CV, Contact me), main area, footer
- Create pull request (PR)
4. Add content for home page. Use bootstrap. Create PR
5. Add content for CV (by default template). User bootstrao. Create PR
6. Create contact me form
- Create EF6 DB cotext (code first). Create PR
- Add and apply EF6 migration. Create PR
- Add UI, model and action method for contact me form. Use data annotation for model validation. In action method track data in DB if the model is valid. Create PR
- Integrate google reCAPTCHA v2 to malicious activity. Nice to have.
7. Host project on the Microsoft Azure App Service.

## If have time.
8. Send email to personal email box when the new message is dropped on the contact me form.
9. Login page. [base URL]/admin
10. After authentication show paginated view of contact me messages. Implement reply functionality
