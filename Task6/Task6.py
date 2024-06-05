from lighthtml import LightElementNode, LightTextNode



def read_book_from_file(file_path):
    with open(file_path, "r", encoding="utf-8") as file:
        return file.read()



def generate_html_from_book_text(book_text):
    # Створюємо екземпляр LightElementNode для кореневого елемента сторінки
    page = LightElementNode('html', 'block', 'double')


    lines = book_text.split('\n')
    for line in lines:
        if line.startswith('Title:'):
            page.add_child(LightElementNode('h1', 'block', 'double', [line.split('Title:')[1].strip()]))
        elif len(line) < 20:
            page.add_child(LightElementNode('h2', 'block', 'double', [line]))
        elif line.startswith(' '):
            page.add_child(LightElementNode('blockquote', 'block', 'double', [line]))
        else:
            page.add_child(LightElementNode('p', 'block', 'double', [line]))


    return page.outerHTML()



book_file_path = "book.txt"


book_text = read_book_from_file(book_file_path)


html_content = generate_html_from_book_text(book_text)


html_file_path = "Testers.html"
with open(html_file_path, "w", encoding="utf-8") as html_file:
    html_file.write(html_content)


print("HTML верстка збережена в файлі:", html_file_path)
