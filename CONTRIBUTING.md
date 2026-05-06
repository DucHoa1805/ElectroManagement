# Contributing to ElectroManagement

Cảm ơn bạn quan tâm đến đóng góp cho ElectroManagement! Hướng dẫn này sẽ giúp bạn hiểu cách đóng góp.

## Code Style

### C# Naming Convention
- Classes: PascalCase (e.g., `ProductController`)
- Methods: PascalCase (e.g., `GetAllHistory`)
- Properties: PascalCase (e.g., `ProductID`)
- Variables: camelCase (e.g., `productName`)
- Constants: UPPER_CASE (e.g., `MAX_ITEMS`)

### File Structure
```
├── Controllers/      # Business logic
├── Views/           # UI Forms
├── Models/          # Data models/entities
└── Database/        # Database helpers
```

## Commit Message Format

```
type(scope): subject

body

footer
```

Types:
- `feat`: Tính năng mới
- `fix`: Sửa lỗi
- `docs`: Tài liệu
- `style`: Formatting, missing semicolons, etc
- `refactor`: Cấu trúc lại code
- `test`: Thêm tests
- `chore`: Cập nhật dependencies

Example:
```
feat(inventory): Add export stock functionality

- Implement ExportStock method
- Add frmExport form
- Update inventory quantity on export
- Add transaction history logging

Closes #123
```

## Branch Naming

- `feature/feature-name` - Tính năng mới
- `bugfix/bug-name` - Sửa lỗi
- `docs/doc-name` - Tài liệu

## Pull Request Process

1. Fork repository
2. Create branch từ `feature/inventory` (hoặc branch phù hợp)
3. Commit changes với message rõ ràng
4. Push to your fork
5. Create Pull Request với description chi tiết
6. Chờ review và approval

## Code Review Checklist

- [ ] Code follows style guide
- [ ] No console.logs or debugging code
- [ ] Comments added for complex logic
- [ ] No hardcoded values (use constants)
- [ ] Exception handling in place
- [ ] SQL queries are parameterized
- [ ] No SQL injection vulnerabilities
- [ ] Tests added (if applicable)

## Testing

Trước khi submit PR:
- Build project (Ctrl+Shift+B)
- Run application (F5)
- Test các tính năng thay đổi
- Kiểm tra không có compile errors
- Kiểm tra không có runtime exceptions

## Questions?

Tạo issue nếu có câu hỏi hoặc cần support.
