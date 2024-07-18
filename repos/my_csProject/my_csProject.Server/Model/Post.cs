/// <summary>
/// POCO 클래스 문법
/// </summary>
/// ANNOTATION 위주의 JPA 느낌
/// 글 등록 MODEL

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


[Table("Posts")] // 테이블 명을 지정
public class Post
{
    [Key] // 기본 키
    [Column("Id")] // 컬럼 명 지정
    public int Id { get; set; }

    [Required] // 필수 필드
    [MaxLength(200)] // 최대 길이 지정
    [Column("Title")] // 컬럼 명 지정
    public string Title { get; set; }

    [Required] // 필수 필드
    [Column("Content", TypeName = "text")] // 데이터 타입 지정
    public string Content { get; set; }

    [Required] // 필수 필드
    [Column("CreatedAt")] // 컬럼 명 지정
    public DateTime CreatedAt { get; set; }
}
