# eHospital Projesi

eHospital, hastane yönetim sistemleri için geliştirilen bir web uygulamasıdır. Bu proje, hem frontend hem de backend bileşenlerini içerir ve N-Tier Architecture prensiplerine göre yapılandırılmıştır.

## Proje Yapısı

### Backend (Sunucu) - eHospitalServer

#### eHospitalServer.Business
- **Business Katmanı**: Uygulamanın iş mantığını içerir.
  - **Services**: İş hizmetleri.
  - **Validators**: Veri doğrulama kuralları.

#### eHospitalServer.DataAccess
- **DataAccess Katmanı**: Veritabanı işlemleri ve altyapı hizmetlerini içerir.
  - **Context**: Veritabanı bağlantıları ve işlemleri.
  - **Repositories**: Veri erişim yöntemleri.
  - **Migrations**: Veritabanı şema değişikliklerini yönetir.

#### eHospitalServer.Entities
- **Entities Katmanı**: Uygulamanın temel veri yapıları ve modelleri.
  - **DTOs**: Veri Transfer Nesneleri.
  - **Models**: Veritabanı varlıkları.
  - **Enums**: Sabit değerler.

#### eHospitalServer.WebAPI
- **WebAPI Katmanı**: Uygulamanın dış dünya ile etkileşime geçtiği katmandır.
  - **Controllers**: HTTP isteklerini işleyen denetleyiciler.
  - **Middlewares**: İstekler arası işlemler için ara yazılımlar.
  - **Abstractions**: API için soyutlamalar.

### Frontend (İstemci) - eHospitalClient

- **Angular** kullanılarak geliştirilmiş kullanıcı arayüzü.
- **DevExtreme Angular**: Gelişmiş kullanıcı arayüzü bileşenleri.
- **@ng-select/ng-select**: Seçim kutuları için kullanılan bileşen.
- **Form Validation**: Form doğrulama kuralları.
- **JWT-decode**: JWT tabanlı kimlik doğrulama.

