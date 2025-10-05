USE PortalNauchnyhPublikatsiyDB;
GO

-- Кафедры (3 записи)
INSERT INTO Departments (Name, Profile) VALUES
(N'Информатика', N'Программная инженерия и ИИ'),
(N'Математика', N'Прикладная математика и алгоритмы'),
(N'Физика', N'Квантовая физика и моделирование');

-- Преподаватели (4 записи)
INSERT INTO Teachers (FullName, Position, Degree, DepartmentId) VALUES
(N'Иванов Иван Иванович', N'Доцент', N'К.т.н.', 1),
(N'Петров Петр Петрович', N'Профессор', N'Д.ф.м.н.', 2),
(N'Сидорова Светлана Сергеевна', N'Ст. преподаватель', N'К.ф.н.', 1),
(N'Кузнецов Константин Константинович', N'Ассистент', N'М.ф.н.', 3);

-- Журналы/Конференции (3 записи)
INSERT INTO JournalsConferences (Name, Rating, Publisher, ISSNISBN) VALUES
(N'IEEE Transactions on AI', N'Q1', N'IEEE', N'0098-5589'),
(N'Journal of Applied Math', N'Q2', N'Springer', N'1110-757X'),
(N'International Conference on Physics', N'Q3', N'ACM', N'978-1-4503-0000-0');

-- Научные направления (2 записи)
INSERT INTO ScientificDirections (Name, Description) VALUES
(N'ИИ и ML', N'Искусственный интеллект и машинное обучение'),
(N'Алгоритмы', N'Оптимизация и сложность алгоритмов');

-- Публикации (5 записей)
INSERT INTO Publications (Title, Type, Year, JournalConferenceId, DOI, FilePath) VALUES
(N'Методы ИИ в образовании', N'Статья', 2024, 1, N'10.1109/TSE.2024.123', N'/files/pub1.pdf'),
(N'Алгоритмы графа', N'Монография', 2023, 2, N'10.1007/978-3-031-00000-0', N'/files/pub2.pdf'),
(N'Тезисы по ML', N'Тезисы', 2022, 3, NULL, N'/files/pub3.pdf'),
(N'Квантовая модель', N'Статья', 2024, 1, N'10.1109/QP.2024.456', N'/files/pub4.pdf'),
(N'Оптимизация', N'Статья', 2023, 2, N'10.1007/978-3-031-20000-0', N'/files/pub5.pdf');

-- PublicationAuthors (связи авторов, 6 записей)
INSERT INTO PublicationAuthors (PublicationId, TeacherId) VALUES
(1, 1), (1, 3),  -- Иванов и Сидорова для pub1
(2, 2),  -- Петров для pub2
(3, 1),  -- Иванов для pub3
(4, 4),  -- Кузнецов для pub4
(5, 2);  -- Петров для pub5

-- Проекты (3 записи)
INSERT INTO Projects (Name, Number, FundingOrg, StartDate, EndDate, LeaderId) VALUES
(N'Грант по ИИ', N'GR-2024-001', N'РФФИ', '2024-01-01', '2025-12-31', 1),
(N'Оптимизация алгоритмов', N'GR-2023-002', N'Минобр', '2023-06-01', NULL, 2),
(N'Квантовая модель', N'GR-2024-003', N'РФФИ', '2024-03-01', '2025-06-30', 4);

-- ProjectParticipants (связи участников, 4 записи)
INSERT INTO ProjectParticipants (ProjectId, TeacherId) VALUES
(1, 3),  -- Сидорова в проекте 1
(2, 1),  -- Иванов в проекте 2
(3, 2);  -- Петров в проекте 3

-- PublicationProjects (связи публикаций с проектами, 3 записи)
INSERT INTO PublicationProjects (PublicationId, ProjectId) VALUES
(1, 1),  -- pub1 из проекта 1
(2, 2),  -- pub2 из проекта 2
(4, 3);  -- pub4 из проекта 3
GO