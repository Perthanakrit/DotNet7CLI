# Clean architecture

### Create solution and add layer

_Create 4 project in solution_
Domain: ดูแลในเรื่องของ Entity สำหรับการสร้างฐานข้อมูลครับ จะถูกนำไปใช้ที่ Project Core ในการพัฒนา Business Logic และใน Project Infra ในตอนที่สร้าง Entity Framework Database Context
Core: เป็น Main Business Logic หลักของระบบครับผม จะมีการกำหนด Interface ในส่วนของ Infra ไว้สำหรับการเชื่อมต่อ Backing Service ภายนอกเช่น Database/Email และจะนำ Interface เหล่านี้มาใช้มีการ Implement ในส่วนของ Business Service Logic ด้วยครับ
Infra: ดูแลในเรื่องของการนำ Interface จาก Core มา Implement เพื่อให้ระบบสามารถเชื่อมต่อกับ 3rd Parties Services ต่างๆได้ เช่น Database Server, Email Server, SMS Gateway
API: เป็นช่องทางสำหรับให้ Client มาเชื่อมต่อเพื่อใช้บริการแลกเปลี่ยนข้อมูลในระบบเรา

### Configuration

Application Configuration ใน ASP.NET Core นั้นจะถูกจัดการมาจากการอ่าน Configuration Data ที่อยู่ในรูปแบบของ Key-Value Pairs จากหลายๆ Configuration Providers ดังนี้

- Settings files เช่น appsettings.json
- Environment Variables
- Azure Key Vault
- Azure App Configuration
- Command-Line Arguments
- Custom Providers, Installed or Created
- Directory Files
- In-Memory .NET Objects
- App secrets (Secret Manager)

**_IConfiguration_**

## Service Lifetime

### Key Concepts

1. Dependency Inversion Principle: คือ Software Design Principle ที่แนะนำชี้ให้เห็นถึงปัญหาเกี่ยวกับเรื่องของ Dependency แต่ไม่ได้บอกว่าใช้เทคนิคอะไรในการแก้ไขปัญหา
2. Inversion of Control (IoC): คือการนำ Dependency Inversion Principle มากำหนดแนวทางการพัฒนาให้ Components อ้างอิงกับ Abstraction แทนการอ้างอิงกับ Concrete Implementation.
3. Dependency Injection (DI): คือ Design Patternในการนำ IoC มาพัฒนา โดยจะทำการ Inject Concrete Implementation ระหว่าง Components
4. IoC Container (DI Container): คือ Programming Framework ที่ช่วยทำ DI ให้โดยอัฒโนมัติ ซึ่งใน ASP.NET Core นั้นมี Build-In IoC Container (DI Container) ให้เราพร้อมใช้ได้อย่างรวดเร็วเลยครับ ช่วยลดขั้นตอน ลด Code ในการพัฒนา DI ลงไปได้เยอะมาก เพียงแต่เราจะต้องเรียนรู้การจัดการ State ของ Components ในขั้นตอนนี้ที่เรียกว่า Service Lifetimes

## Domain Project

## Core Project

Project นี้เราจะทำหน้าที่กำหนดในเรื่องของมาตราฐานในการพัฒนา Backing Service (เช่นการต่อ Database, Logging, Email) ผ่าน Interface(Infrastructure) (ต่อไปนี้จะขอเรียกว่า Infrastructure Interface) ส่วนการนำ Interface ไปพัฒนาต่อนั้นจะเป็นหน้าที่ของทาง Infra Project นะครับ

> ใช้ **_Repository Pattern_** ช่วยแยกความสัมพันธ์ระหว่าง Business Domain Model (อยู่ใน Domain Project) และ Data Access Layer (อยู่ใน Infra Project)
