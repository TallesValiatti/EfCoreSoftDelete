# Implementing Soft Delete with EF Core in .NET Applications

This repository provides a detailed guide on implementing Soft Delete functionality in .NET applications using Entity Framework Core. The solution covers the integration of Soft Delete within a .NET Web API, demonstrating how to modify your entities and DbContext to support this feature seamlessly. By leveraging EF Core's capabilities, the implementation ensures that deleted records are retained in the database, allowing for potential recovery or audit purposes while keeping them hidden from regular queries.

The repository walks through the entire process, from setting up the .NET Web API, configuring EF Core to handle Soft Delete, to demonstrating how to interact with the API to perform soft deletions and retrieve only active records. This practical example serves as a valuable resource for developers looking to enhance their .NET applications with efficient Soft Delete mechanisms, ensuring data
