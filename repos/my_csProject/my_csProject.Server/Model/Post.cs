/// <summary>
/// POCO Ŭ���� ����
/// </summary>
/// ANNOTATION ������ JPA ����
/// �� ��� MODEL

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


[Table("Posts")] // ���̺� ���� ����
public class Post
{
    [Key] // �⺻ Ű
    [Column("Id")] // �÷� �� ����
    public int Id { get; set; }

    [Required] // �ʼ� �ʵ�
    [MaxLength(200)] // �ִ� ���� ����
    [Column("Title")] // �÷� �� ����
    public string Title { get; set; }

    [Required] // �ʼ� �ʵ�
    [Column("Content", TypeName = "text")] // ������ Ÿ�� ����
    public string Content { get; set; }

    [Required] // �ʼ� �ʵ�
    [Column("CreatedAt")] // �÷� �� ����
    public DateTime CreatedAt { get; set; }
}
